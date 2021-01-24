    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace randomseed
    {
    class Program
    {
        static void Main(string[] args)
        {
            string first = "fir";
            string last = "LastName";
            string firstlast = first.Substring(0, first.Length > 4 ? 4 : first.Length)
                + last.Substring(0, last.Length > 4 ? 4 : last.Length);
            int seed = 0;
            Int32.TryParse(firstlast, out seed);
          
            Console.Write($"uniqueString = { GenerateStringNameGuid(seed)} \n");
            Console.Write($"uniqueString = { GenerateStringNameGuid(seed)} \n");
            Console.Write($"uniqueString = { GenerateStringNameGuid(seed)} \n");
        }
        public static string GenerateStringNameGuid(int seed)
        {
            var r = new Random(seed + Guid.NewGuid().GetHashCode());
            var guid = new byte[16];
            r.NextBytes(guid);
            return new Guid(guid).ToString();
        }
    }
