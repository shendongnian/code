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
                        string uniqueString = firstlast + GenerateStringNameGuid(seed);
            string u2 = firstlast + GenerateStringNameGuid(seed);
            string u3 = firstlast + GenerateStringNameGuid(seed);
            Console.Write($"uniqueString = { uniqueString} \n");
            Console.Write($"uniqueString = { u2} \n");
            Console.Write($"uniqueString = { u3} \n");
        }
        public static string GenerateStringNameGuid(int seed)
        {
            var r = new Random(seed + Guid.NewGuid().GetHashCode());
            var guid = new byte[16];
            r.NextBytes(guid);
            return new Guid(guid).ToString();
        }
    }
