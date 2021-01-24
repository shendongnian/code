    using System;
    using System.Linq;
    
    namespace Test
    {
        public class Program
        {
            static void Main(string[] args)
            {
                var Files = new string[] { "file1", "file2" };
    
                var withMetaData = Files.Select(z =>
                    new { file = z, IsFile1 = z == "file1", IsFile2 = z == "file2"});
    
                // You can now OrderBy or GroupBy or whatever you fancy here
    
                foreach (var fileWithMetaData in withMetaData)
                {
                    Console.WriteLine(fileWithMetaData);
                }
    
                Console.ReadLine();
            }
        }
    }
