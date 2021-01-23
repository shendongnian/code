    using System;
    using System.IO;
    
    namespace RenameVersion2
    {
        class Program
        {
            static void Main(string[] args)
            {
                foreach (var arg in args)
                {
                    if (arg.Length == 0)
                        System.Environment.Exit(0);
    
                    string MyString = Path.GetFileNameWithoutExtension(arg);
                    String NewFileName = MyString.Remove(0, 15);
    
    
                    string path = Path.GetDirectoryName(arg)
                       + Path.DirectorySeparatorChar
                       + MyString
                       + Path.GetExtension(arg);
    
                    string newPath = Path.GetDirectoryName(arg)
                       + Path.DirectorySeparatorChar
                       + NewFileName
                       + Path.GetExtension(arg);
    
    
                    File.Move(path, newPath);
                }
    
    
            }
        }
    }
