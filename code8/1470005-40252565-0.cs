    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace StackOverflowSnippets
    {
        class Program
        {
            static void Main(string[] args)
            {
                String path = @"C:\smth"; String pattern = "*.html";
    
                Console.WriteLine("__" + checkifDirectoryContainsFilesWithSpecifiedExtention(path, pattern));
    
                Console.ReadLine();
            }
    
            private static bool checkifDirectoryContainsFilesWithSpecifiedExtention(string path, string fileExestention) //Like C:\\smth, *.html
            {
                foreach (string f in Directory.GetFiles(path, fileExestention))
                {
                    return true;
                }
                foreach (string d in Directory.GetDirectories(path))
                {
                    if (checkifDirectoryContainsFilesWithSpecifiedExtention(Path.Combine(path, d), fileExestention))
                    {
                        return true;
                    }
                }
    
                return false;
            }
        }
    }
