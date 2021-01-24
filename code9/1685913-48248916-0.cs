    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication19
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            const string FOLDER = @"c:\temp";
            static XmlWriter writer = null;
            static void Main(string[] args)
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                writer = XmlWriter.Create(FILENAME, settings);
                writer.WriteStartDocument(true);
                DirectoryInfo info = new DirectoryInfo(FOLDER);
                WriteTree(info);
                writer.WriteEndDocument();
                writer.Flush();
                writer.Close();
            }
            static long WriteTree(DirectoryInfo info)
            {
                long size = 0;
                writer.WriteStartElement("Folder");
                try
                {
                    writer.WriteAttributeString("name", info.Name);
                    writer.WriteAttributeString("numberSubFolders", info.GetDirectories().Count().ToString());
                    writer.WriteAttributeString("numberFiles", info.GetFiles().Count().ToString());
                    writer.WriteAttributeString("date", info.LastWriteTime.ToString());
                    foreach (DirectoryInfo childInfo in info.GetDirectories())
                    {
                        size += WriteTree(childInfo);
                    }
                }
                catch (Exception ex)
                {
                    string errorMsg = string.Format("Exception Folder : {0}, Error : {1}", info.FullName, ex.Message);
                    Console.WriteLine(errorMsg);
                    writer.WriteElementString("Error", errorMsg);
                }
                FileInfo[] fileInfo = null;
                try
                {
                    fileInfo = info.GetFiles();
                }
                catch (Exception ex)
                {
                    string errorMsg = string.Format("Exception FileInfo : {0}, Error : {1}", info.FullName, ex.Message);
                    Console.WriteLine(errorMsg);
                    writer.WriteElementString("Error", errorMsg);
                }
                if (fileInfo != null)
                {
                    foreach (FileInfo finfo in fileInfo)
                    {
                        try
                        {
                            writer.WriteStartElement("File");
                            writer.WriteAttributeString("name", finfo.Name);
                            writer.WriteAttributeString("size", finfo.Length.ToString());
                            writer.WriteAttributeString("date", info.LastWriteTime.ToString());
                            writer.WriteEndElement();
                            size += finfo.Length;
                        }
                        catch (Exception ex)
                        {
                            string errorMsg = string.Format("Exception File : {0}, Error : {1}", finfo.FullName, ex.Message);
                            Console.WriteLine(errorMsg);
                            writer.WriteElementString("Error", errorMsg);
                        }
                    }
                }
                writer.WriteElementString("size", size.ToString());
                writer.WriteEndElement();
                return size;
            }
        }
    }
