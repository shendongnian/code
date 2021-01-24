    using System;
    using System.Linq;
    namespace Rextester
    {
       public class Program
       {
        private static Random random = new Random();
        
		public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%&";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        
		public static void Main(string[] args)
        {
            //Your code goes here
            Console.WriteLine(RandomString(8));
        }
      }
    }
