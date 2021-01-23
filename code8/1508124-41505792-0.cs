    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApp
    {
        class Program
        {
            static void Main()
            {
                string serverpath = @"C:\AAA\New folder\";
    
                Regex re = new Regex(@"\d{2}\.\d{2}\.\d{4}");
                var dirs = from dir in
                           Directory.EnumerateDirectories(serverpath, "*", SearchOption.AllDirectories)
                           where re.IsMatch(dir)
                           select dir;
            }
        }
    }
    
