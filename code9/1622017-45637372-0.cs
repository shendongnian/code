    using System;
    using System.Collections.Generic;
    using System.IO;
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
            XmlSerializer serializer = new XmlSerializer(typeof(Folder));
            StringReader reader = new StringReader(xml);
            Folder folders = (Folder)serializer.Deserialize(reader);
            searchFolders(folders, startingLetter);
            reader.Close();
            return searchFolderResults;
        }
        private static List<string> searchFolderResults = new List<string>();
        private static void searchFolders(Folder node, char startingLetter)
        {
            if (node.Name.StartsWith(startingLetter.ToString()))
            {
                searchFolderResults.Add(node.Name);
            }
            foreach (Folder folder in node.children)
                searchFolders(folder, startingLetter);           
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
