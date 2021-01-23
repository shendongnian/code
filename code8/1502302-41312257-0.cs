    public static class Constants
    {
        public static class Group1
        {
            internal const string String1 = "String1";
        }
    }
    internal class Program
    {
        internal static void Main()
        {
            Console.WriteLine(Constants.Group1.String1);
        }
    }
