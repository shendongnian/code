    class Program
    {
        static void Main(string[] args)
        {
            var fail = Constants.DirectCast<Constants.ReturnCode>(-1);
            var success = Constants.DirectCast<Constants.ReturnCode>(0);
            var warning = Constants.DirectCast<Constants.ReturnCode>(1);
            Console.WriteLine(fail);
            Console.WriteLine(success);
            Console.WriteLine(warning);
            Console.ReadLine();
        }
    }
    public class Constants
    {
        public enum ReturnCode
        {
            Fail = -1,
            Success = 0,
            Warning = 1
        }
        public static T DirectCast<T>(object o)
        {
            T value = (T)o;
            if (value == null && o != null)
            {
                throw new InvalidCastException();
            }
            return value;
        }
    }
