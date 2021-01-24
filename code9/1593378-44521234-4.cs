    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication62
    {
        class Program
        {
            const string INPUT_FILENAME = @"c:\temp\test.xml";
            const string OUTPUT_FILENAME = @"c:\temp\test2.xml";
            static void Main(string[] args)
            {
                new Node(INPUT_FILENAME, OUTPUT_FILENAME);
            }
        }
        public class Node
        {
            public static Node root = new Node();
            public List<Node> children { get; set; }
            public int level { get; set; }
            public string item { get; set; }
            public int qty { get; set; }
            public string rev { get; set; }
            public string status { get; set; }
            public string mostActive { get; set; }
            public Node() { }
            public Node(string in_filename, string out_filename)
            {
                XDocument doc = XDocument.Load(in_filename);
                XElement xmlRoot = doc.Root;
                GetNodesRecursive(root, xmlRoot);
                SortItemRecursive(root);
                XElement newDoc = new XElement("ABCD");
                GetXmlRecursive(root, newDoc);
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.NewLineHandling = NewLineHandling.Entitize;
                XmlWriter writer = XmlWriter.Create(out_filename, settings);
                writer.WriteRaw(newDoc.ToString());
                writer.Flush();
                writer.Close();
            }
            public void GetNodesRecursive(Node parent, XElement xmlParent)
            {
                foreach (XElement xyz in xmlParent.Elements("XYZ"))
                {
                    if (parent.children == null)
                    {
                        parent.children = new List<Node>();
                    }
                    Node newChild = new Node();
                    parent.children.Add(newChild);
                    newChild.level = (int)xyz.Element("LEVEL");
                    newChild.item = (string)xyz.Element("ITEM");
                    newChild.qty = (int)xyz.Element("QTY");
                    newChild.rev = (string)xyz.Element("REV");
                    newChild.status = (string)xyz.Element("STATUS");
                    newChild.mostActive = (string)xyz.Element("ITEM_MOST_ACTIVE_STATUS");
                    GetNodesRecursive(newChild, xyz);
                }
            }
            public void GetXmlRecursive(Node parent, XElement xmlParent)
            {
                xmlParent.Add(new object[] {
                    new XElement("LEVEL", parent.level),
                    new XElement("ITEM", parent.item),
                    new XElement("QTY", parent.qty),
                    new XElement("REV", parent.rev),
                    new XElement("STATUS", parent.status),
                    new XElement("ITEM_MOST_ACTIVE_STATUS", parent.mostActive)
                });
                if (parent.children != null)
                {
                    foreach (Node node in parent.children)
                    {
                        XElement child = new XElement("XYZ");
                        xmlParent.Add(child);
                        GetXmlRecursive(node, child);
                    }
                }
            }
            public void SortItemRecursive(Node parent)
            {
                if (parent.children != null)
                {
                    parent.children = parent.children.OrderBy(x => x.item).ToList();
                    foreach (Node child in parent.children)
                    {
                        SortItemRecursive(child);
                    }
                }
            }
        }
    }
