using System;
using System.Reflection;

namespace sequor.testris.Classes
{
    public class Reflexao
    {


        public static void SetPropriedade(object target, string propertyName, object value)
        {
            try { target.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, target, new object[] { value }); }
            catch
            { }
        }

        public static T GetPropriedade<T>(object source, string propertyName)
        {
            try { return (T)source.GetType().InvokeMember(propertyName, BindingFlags.GetProperty, null, source, new Object[] { }); }
            catch
            { }
            return default(T);
        }
        
        public static T GetPropriedadeEstatico<T>(object source, string propertyName)
        {
            try { return (T)source.GetType().InvokeMember(propertyName, BindingFlags.GetProperty | BindingFlags.Static, null, source, new Object[] { }); }
            catch
            { }
            return default(T);
        }

        public static T GetCampo<T>(object source, string propertyName)
        {
            try { return (T)source.GetType().GetField(propertyName).GetValue(source); }
            catch
            { }
            return default(T);
        }
        public static EventInfo GetEvento(object source, string propertyName)
        {
            try { return source.GetType().GetEvent(propertyName); }
            catch
            { }
            return null;
        }

        public static T Metodo<T>(object target, string methodName, params object[] args)
        {
            try { return (T)target.GetType().InvokeMember(methodName, BindingFlags.InvokeMethod, null, target, args); }
            catch
            { }
            return default(T);
        }
        public static void Metodo(object target, string methodName, params object[] args)
        {
            try { target.GetType().InvokeMember(methodName, BindingFlags.InvokeMethod, null, target, args); }
            catch
            { }
        }

        public static T Metodo<T>(object target, string methodName)
        {
            try { return (T)target.GetType().InvokeMember(methodName, BindingFlags.InvokeMethod, null, target, new Object[] { }); }
            catch (Exception exc) { throw new Exception(string.Format("Erro ao executar o método '{0}'", methodName), exc); }
        }

        public static void MetodoSRetorno(object target, string methodName)
        {
            try { target.GetType().InvokeMember(methodName, BindingFlags.InvokeMethod, null, target, new Object[] { }); }
            catch (Exception exc) { throw new Exception(string.Format("Erro ao executar o método '{0}'", methodName), exc); }
        }

        public static void MetodoSRetorno(object target, string methodName, params object[] args)
        {
            try { target.GetType().InvokeMember(methodName, BindingFlags.InvokeMethod, null, target, args); }
            catch (Exception exc) { throw new Exception(string.Format("Erro ao executar o método '{0}'", methodName), exc); }
        }
    }

}
