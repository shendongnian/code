    public static class StringExtensions
    {
        public static string Capitalize(this string source, char separator)
        {
            return 
                string.Join(" ", source.Split(new char[] { separator }).Select(
                    c =>
                    string.Format("{0}{1}", c[0].ToString().ToUpper(), c.Length > 1 ? c.Substring(1) : "")));
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            var testString = "web_shop_settings";
            Console.WriteLine(testString.Capitalize('_'));
        }
    }
