    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml =
                    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                    "<folders name=\"c\">" +
                        "<folder name=\"program files\">" +
                            "<folder name=\"uninstall information\" />" +
                        "</folder>" +
                        "<folder name=\"users\" />" +
                    "</folders>";
                List<string> folders =  Folders.FolderNames(xml, 'u').ToList();
            }
        }
        [XmlRoot(ElementName = "folder")]
        public class Folder
        {
            [XmlAttribute(AttributeName = "name")]
            public string Name { get; set; }
        }
        [XmlRoot(ElementName = "folders")]
        public class Folders
        {
            [XmlElement("folder")]
            public List<Folder> folders { get; set; }
            public static IEnumerable<string> FolderNames(string xml, char startingLetter)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Folders));
                StringReader reader = new StringReader(xml);
                Folders folders = (Folders)serializer.Deserialize(reader);
                List<string> result = new List<string>();
                foreach (Folder folder in folders.folders)
                {
                    if (folder.Name.StartsWith(startingLetter.ToString()))
                    {
                        result.Add(folder.Name);
                    }
                }
                reader.Close();
                return result;
            }
        }
    }
