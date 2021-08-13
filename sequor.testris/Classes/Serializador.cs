using Newtonsoft.Json;
using sequor.testris.Componentes;
using System;

namespace sequor.testris.Classes
{
    class Serializador
    { 
        public class JSON
        {





            public static string Salvar<T>(T Dados, Formatting Formatting = Formatting.None)
            {
                if (Dados == null) throw new Exception();

                var o = JsonConvert.SerializeObject(Dados, typeof(T),
                    new JsonSerializerSettings()
                    {

                        Formatting = Formatting
                    });

                return o;
            }

            public static T Ler<T>(string Fonte)
            {

                try
                {
                    var cfg = new JsonSerializerSettings()
                    {
                        TypeNameHandling = TypeNameHandling.Auto,
                        Error = HandleDeserializationError

                    };
                    cfg.Converters.Add(new BlocoConverter());


                    return JsonConvert.DeserializeObject<T>(Fonte, cfg);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            private static void HandleDeserializationError(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs e)
            {
            }

            class BlocoConverter : JsonConverter
            {
                public override bool CanConvert(Type objectType)
                {

                    return (objectType == typeof(absBloco));
                }

                public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)


                {



                    //string displayName = string.Empty;
                    //string address = string.Empty;
                    //while (reader.Read())
                    //{

                    //    var dddddd = reader["TipoBloco"];


                    //    var tokenType = reader.TokenType;
                    //    if (reader.TokenType == JsonToken.PropertyName)
                    //    {
                    //        reader




                    //        var val = (reader.Value as string) ?? string.Empty;
                    //        if (val == "DisplayName")
                    //        {
                    //            displayName = reader.ReadAsString();
                    //        }
                    //        if (val == "Address")
                    //        {
                    //            address = reader.ReadAsString();
                    //        }
                    //    }

                    //    if (reader.TokenType == JsonToken.EndObject)
                    //    {
                    //        break;
                    //    }
                    //}

                    //var dd = reader.Read();

                    return serializer.Deserialize(reader, typeof(BlocoI));
                }

                public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
                {
                    //serializer.Serialize(writer, value, typeof(Product));
                }
            }

        }
    }
}
