    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    [XmlRoot(ElementName = "folder")]
    public class Folder
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "folder")]
        public List<Folder> children { get; set; }
    }
    public class Folders
    {
        public static IEnumerable<string> FolderNames(string xml, char startingLetter)
        {
            return
                from row in XDocument.Parse(xml).Descendants()
                where row.FirstAttribute.Value.StartsWith(startingLetter.ToString())
                select row.FirstAttribute.Value;
        }
        public static void Main(string[] args)
        {
            string xml =
                "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                "<folder name=\"c\">" +
                    "<folder name=\"program files\">" +
                        "<folder name=\"uninstall information\" />" +
                        "<folder name=\"cusers3\" />" +
                    "</folder>" +
                    "<folder name=\"users\">" +
                        "<folder name=\"users2\" />" +
                    "</folder>" +
                "</folder>";
            foreach (string name in Folders.FolderNames(xml, 'c'))
                Console.WriteLine(name);
        }
    }
