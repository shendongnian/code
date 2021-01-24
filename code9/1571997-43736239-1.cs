    using System.Reflection;
    namespace ConsoleApplication4
    {
        class Program
        {
           static void Main(string[] args)
           {
            var className = "RegisterTelegramCommand";
            Type[] paramTypes = { typeof(object), typeof(string[]) };
            var cmd = Activator.CreateInstance("ConsoleApplication4", "ConsoleApplication4." + className);
            Object p = cmd.Unwrap();
            var method = p.GetType().GetMethod("Execute", BindingFlags.Public | BindingFlags.Instance, null, paramTypes, null);
            var res = method.Invoke(p, new object[] { null, args }).ToString();
            Console.Read();
        }
    }
    public class RegisterTelegramCommand 
    {
        public string Message
        {            get            {                return "a";
            }
        }
        public string Execute(object paramObject, string[] param)
        {
            return param[0] + " " + param[2];
        }
    }
}
