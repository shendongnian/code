    using System;
        using System.IO;
        class Test
            {
                static void Main(string[] args)
                 {
                    Console.WriteLine("Please :");
                    string hely = Console.ReadLine();
    
                    try
                    {
                       string[] __file = Directory.GetFiles(hely);
                       string[] __dir = Directory.GetDirectories(hely);
                       foreach (string i in __file)
                       {
                          FileInfo fajl = new FileInfo(i);
                           Console.WriteLine("{0},{1},{2}", fajl.Name, fajl.Extension, fajl.LastWriteTime.ToString());
                       }
                    
                       foreach (string i in __dir)
                       {
                          DirectoryInfo _file = new DirectoryInfo(i);
                          Console.WriteLine("{0},{1},{2}", _file.Name, _file.Extension, _file.LastWriteTime.ToString());
                       }
                    }
                    catch(System.IO.DirectoryNotFoundException ex)
                    {
                        Console.WriteLine("Directory not found");
                    }
    
                    Console.ReadKey();
                 }
    
            }
