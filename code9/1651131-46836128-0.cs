Program.cs
------------
    using System;
    using System.IO;
    using System.Xml.Linq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    var basePath = Console.ReadLine();
                    string[] filesindirectory = Directory.GetFiles(basePath, "*.xml");
                    foreach (string fp in filesindirectory)
                    {
                        string file_content = escape_string(File.ReadAllText(fp), 0);
                        XDocument doc = XDocument.Parse(file_content, LoadOptions.PreserveWhitespace);
                        XElement test = new XElement("path", fp.ToString());
                        doc.Root.Add(test);
                        File.WriteAllText(Path.ChangeExtension(fp, "out"), escape_string(doc.ToString(), 1).ToString());
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                }
                Console.ReadKey();
                return;
            }
            private static string escape_string (string input_string, int option){
                switch (option)
                {
                    case 0:
                        return input_string.Replace("&", "&amp;").ToString();
                    case 1:
                        return input_string.Replace("&amp;", "&").ToString();
                    default:
                        return null;
                    
                }
            }
        }
    }
sample.xml
