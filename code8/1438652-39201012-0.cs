    using System.IO;
    namespace ConsoleApplication15
    {
        class Program
        {
            static void Main(string[] args)
            {
                var projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                var file = Path.Combine(projectFolder, @"TestData\Test.xml");
            }
        }
    }
