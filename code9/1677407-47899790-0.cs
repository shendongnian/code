    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    
    namespace Test {
        class Program {
            static void Main(string[] args) {
                var files = new string[] {
                    @"C:\temp\image\a.jpg",
                    @"C:\temp\image\b.bmp",
                    @"c:\temp\bin\my.exe",
                    @"c:\temp\document\resume.doc",
                    @"c:\temp\document\timetable.xlsx",
                };
                var dirNames = files.Select(x => new DirectoryInfo(Path.GetDirectoryName(x)).Name);
                Debug.WriteLine($"dirNames={string.Join(",", dirNames)}");
            }
        }
    }
