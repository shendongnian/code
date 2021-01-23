    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication31
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlDocument xmlDocument = new XmlDocument();
                try
                {
                    string contents = @"<?xml version='1.0' encoding='ISO-8859-1' standalone='yes'?>
                    <!DOCTYPE content [<!ENTITY ouml '&#246;'>]>
                    <content>Test &ouml; Test
                    Test</content>";
                    MemoryStream stream = new MemoryStream();
                    XmlTextWriter writer = new XmlTextWriter(stream, Encoding.GetEncoding("ISO-8859-1"));
                    writer.WriteString(contents);
                    writer.Flush();
                    byte[] bytes = new byte[stream.Length];
                    stream.Position = 0;
                    stream.Read(bytes, 0, (int)stream.Length);
                    Console.WriteLine(Encoding.GetEncoding("ISO-8859-1").GetString(bytes));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
               
            }
        }
     
    }
