using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;

namespace sequor.testris.Classes
{
    public class DbAcess : IDisposable
    {
        /// <summary>
        /// Conectado
        /// </summary>
        public bool Conectado
        {
            get
            {
                try { return Conn.State == ConnectionState.Open; }
                catch { return false; }
            }
        }
        IDbConnection Conn { get; }
        IDataReader Reader;
        public DbAcess(IDbConnection Conn)
        {
            if (Conectado) throw new Exception("Conexão já aberta!");

            this.Conn = Conn;
            this.Conn.Open();
        }












        /// <summary>
        /// Executes the System.Data.IDbCommand.CommandText against the System.Data.IDbCommand.Connection and builds an System.Data.IDataReader.
        /// </summary>
        /// <param name="Query"></param>
        /// <param name="Params"></param>
        /// <returns></returns>
        public IDataReader ExecuteReader(string Query, params DbParameter[] Params)
        {
            try
            {
                Reader.Close();
                Reader.Dispose();
                Reader = null;
            }
            catch { Reader = null; }

            var Command = Conn.CreateCommand();
            switch (Conn.GetType().ToString())
            {
                case "System.Data.SqlClient.SqlConnection":
                    Command.CommandText = Query.ToLower();
                    Command.CommandTimeout = int.MaxValue;
                    break;
                case "Npgsql.NpgsqlConnection":
                default:
                    Command.CommandText = Query;
                    break;
            }

            foreach (var Param in Params)
            {
                switch (Conn.GetType().ToString())
                {
                    case "Npgsql.NpgsqlConnection": Param.ParameterName = Param.ParameterName.ToLower(); break;
                }
                Command.Parameters.Add(Param);
            }

            return Reader = Command.ExecuteReader();
        }
        /// <summary>
        /// Executes an SQL statement against the Connection object of a .NET Framework data provider, and returns the number of rows affected.
        /// </summary>
        /// <param name="Query"></param>
        /// <param name="ReturnId"></param>
        /// <param name="Params"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string Query, bool ReturnId, params DbParameter[] Params)
        {
            try
            {
                Reader.Close();
                Reader.Dispose();
                Reader = null;
            }
            catch { Reader = null; }

            var Command = Conn.CreateCommand();

            switch (Conn.GetType().ToString())
            {
                case "System.Data.SqlClient.SqlConnection":
                    Command.CommandText = Query.ToLower();
                    Command.CommandTimeout = int.MaxValue;
                    break;
                case "Npgsql.NpgsqlConnection":
                    Command.CommandText = Query;
                    break;
            }

            foreach (var Param in Params)
            {
                switch (Conn.GetType().ToString())
                {
                    case "Npgsql.NpgsqlConnection": Param.ParameterName = Param.ParameterName.ToLower(); break;
                }
                Command.Parameters.Add(Param);
            }

            if (!ReturnId)
                return Command.ExecuteNonQuery();
            else
            {
                Command.ExecuteNonQuery();
                switch (Conn.GetType().ToString())
                {
                    case "System.Data.SqlClient.SqlConnection": Command.CommandText = "SELECT @@IDENTITY"; break;
                    case "Npgsql.NpgsqlConnection": Command.CommandText = "select currval('id');"; break;  // ????
                }

                var Retorno = 0;
                try { Retorno = Convert.ToInt32(Command.ExecuteScalar().ToString()); }
                catch (Exception)
                { }
                return Retorno;
            }
        }



        public List<T> ExecuteReaderToList<T>(string Query, params DbParameter[] Params)
        {
            var retorno = new List<T>();

            var reader = ExecuteReader(Query, Params);

            while (reader.Read())
                if (reader != null)
                {
                    var @new = Activator.CreateInstance<T>();

                    var objeto = DbToObject<T>(this, reader, @new);

                    retorno.Add(objeto);
                }

            return retorno;
        }
        public T ExecuteReaderToObject<T>(string Query, params DbParameter[] Params)
        {
            var retorno = new List<T>();

            var reader = ExecuteReader(Query, Params);

            while (reader.Read())
                if (reader != null)
                {
                    var @new = Activator.CreateInstance<T>();

                    var objeto = DbToObject<T>(this, reader, @new);

                    retorno.Add(objeto);
                }

            if (retorno.Count > 1)
                throw new Exception("mais de um objeto encontrado!");

            return retorno.FirstOrDefault();
        }





        /// <summary>
        /// Creates a new instance of an System.Data.IDbDataParameter object.
        /// </summary>
        /// <param name="Objeto"></param>
        /// <param name="Nome"></param>
        /// <returns></returns>
        public DbParameter ToDbParameter(object Objeto, string Nome)
        {
            DbParameter Param = Conn.CreateCommand().CreateParameter() as DbParameter;

            return ToDbParameter(Param, Objeto, Nome.ToLower());
        }
        public DbParameter ToDbParameter(DbParameter Param, object Value, string Name)
        {
            DbType Tipo = DbType.String;
            if (Value != null)
            {
                switch (Type.GetTypeCode(Value.GetType()))
                {
                    case TypeCode.Empty:
                        throw new SystemException("Invalid data type");
                    case TypeCode.Object:
                        if (Value.GetType().ToString() == "System.Drawing.Bitmap")
                        {
                            Tipo = DbType.Binary;
                            MemoryStream ms = new MemoryStream();
                            Image imagem = (Image)Value;
                            if (imagem != null)
                            {
                                imagem.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            }
                            Value = (imagem != null ? ms.GetBuffer() : null);
                        }
                        else
                        {
                            Tipo = DbType.Object;
                        }
                        break;
                    case TypeCode.DBNull:
                    case TypeCode.Char:
                    case TypeCode.SByte:
                    case TypeCode.UInt16:
                    case TypeCode.UInt32:
                    case TypeCode.UInt64:
                        // Throw a SystemException for unsupported data types.
                        throw new SystemException("Invalid data type");

                    case TypeCode.Boolean:
                        Tipo = DbType.Boolean;
                        break;
                    case TypeCode.Byte:
                        Tipo = DbType.Byte;
                        break;
                    case TypeCode.Int16:
                        Tipo = DbType.Int16;
                        break;
                    case TypeCode.Int32:
                        Tipo = DbType.Int32;
                        break;
                    case TypeCode.Int64:
                        Tipo = DbType.Int64;
                        break;
                    case TypeCode.Single:
                        Tipo = DbType.Single;
                        break;
                    case TypeCode.Double:
                        Tipo = DbType.Double;
                        break;
                    case TypeCode.Decimal:
                        Tipo = DbType.Decimal;
                        break;
                    case TypeCode.DateTime:
                        Tipo = DbType.DateTime;
                        if ((DateTime)Value == DateTime.MinValue)
                        {
                            Value = DateTime.MinValue.AddYears(1899);
                        }
                        break;
                    case TypeCode.String:
                        Tipo = DbType.String;
                        break;
                    default:
                        throw new SystemException("Unknown Value Type");
                }
            }
            else
            {
                Value = string.Empty;
            }
            Param.DbType = Tipo;
            Param.ParameterName = "@" + Name.ToLower();
            Param.Direction = ParameterDirection.Input;
            Param.Value = Value;
            return Param;
        }
        ObjectType GetObjectType(object Value)
        {
            ObjectType objType = ObjectType.Null;
            if (Value != null)
            {
                string type = string.Empty;
                try
                {
                    type = Value.GetType().ToString().Split('.')[1].ToLower(CultureInfo.InvariantCulture);
                }
                catch
                { }
                if (type == "boolean") return ObjectType.Boolean;
                else if (type == "datetime") return ObjectType.DateTime;
                else if ("+byte+sbyte+uint16+int16+uint32+int32+int64+single+double+decimal".IndexOf(type) > 0) return ObjectType.Numeric;
                else if (type == "byte[]") return ObjectType.Image;
                else objType = ObjectType.String;
            }
            return objType;
        }
        public T DbToObject<T>(DbAcess Db, IDataReader r, T o)
        {
            foreach (var p in o.GetType().GetProperties())
            {
                if (p.PropertyType == typeof(string))
                    Reflexao.SetPropriedade(o, p.Name, Db.GetDbValue<string>(r[p.Name]));
                else if (p.PropertyType == typeof(decimal))
                    Reflexao.SetPropriedade(o, p.Name, Db.GetDbValue<decimal>(r[p.Name]));
                else if (p.PropertyType == typeof(int))
                    Reflexao.SetPropriedade(o, p.Name, Db.GetDbValue<int>(r[p.Name]));
                else if (p.PropertyType == typeof(DateTime))
                    Reflexao.SetPropriedade(o, p.Name, Db.GetDbValue<DateTime>(r[p.Name]));
                else if (p.PropertyType == typeof(char))
                    Reflexao.SetPropriedade(o, p.Name, Db.GetDbValue<char>(r[p.Name]));
                else if (p.PropertyType == typeof(object))
                    Reflexao.SetPropriedade(o, p.Name, Db.GetDbValue<object>(r[p.Name]));
            }

            return o;
        }
        public T GetDbValue<T>(object Value)
        {
            object result = null;

            TypeCode typeCode = Type.GetTypeCode(typeof(T));

            switch (typeCode)
            {
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                    if (Value != null || !Convert.IsDBNull(Value))
                    {
                        result = (GetObjectType(Value) == ObjectType.Numeric ? Value : 0);
                    }
                    else
                    {
                        result = 0;
                    }
                    break;
                case TypeCode.Decimal:
                    if (Value != null || !Convert.IsDBNull(Value))
                    {
                        result = (GetObjectType(Value) == ObjectType.Numeric ? Value : 0);
                    }
                    else
                    {
                        result = 0;
                    }
                    break;
                case TypeCode.Double:
                    if (Value != null || !Convert.IsDBNull(Value))
                    {
                        result = (GetObjectType(Value) == ObjectType.Numeric ? Value : 0);
                    }
                    else
                    {
                        result = 0;
                    }
                    break;
                case TypeCode.String:
                    if (Value != null || !Convert.IsDBNull(Value))
                    {
                        result = (GetObjectType(Value) == ObjectType.String ? Value : (GetObjectType(Value) == ObjectType.Numeric ? Value : string.Empty));
                    }
                    else
                    {
                        result = string.Empty;
                    }
                    break;
                case TypeCode.DateTime:
                    if (Value != null || !Convert.IsDBNull(Value))
                    {
                        result = (GetObjectType(Value) == ObjectType.DateTime ? Value : DateTime.MinValue);
                    }
                    else
                    {
                        result = DateTime.MinValue;
                    }
                    break;
                case TypeCode.Boolean:
                    if (Value != null || !Convert.IsDBNull(Value))
                    {
                        if (GetObjectType(Value) == ObjectType.Boolean)
                        {
                            result = Value;
                        }
                        else if (GetObjectType(Value) == ObjectType.Numeric)
                        {
                            result = (int.Parse(Value.ToString()) == 1 ? true : false);
                        }
                        else
                        {
                            result = false;
                        }
                    }
                    else
                    {
                        result = false;
                    }
                    break;
                case TypeCode.Object:
                    if (Value != DBNull.Value && typeof(T).ToString() == "System.Drawing.Image")
                    {
                        byte[] buffer = (byte[])Value;
                        MemoryStream memStream = new MemoryStream(buffer);
                        try
                        {
                            result = Image.FromStream(memStream);
                        }
                        catch
                        { }
                        return (T)result;
                    }
                    break;
            }
            return (T)Convert.ChangeType(result, typeof(T));
        }
        public void Dispose()
        {
            try
            {
                Conn.Close();
                Reader = null;
            }
            catch (Exception)
            {

            }
        }
        enum ObjectType
        {
            String,
            Numeric,
            Decimal,
            Boolean,
            DateTime,
            Null,
            Image
        };
    }
}