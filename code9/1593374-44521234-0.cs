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
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                new Node(FILENAME);
            }
        }
        public class Node
        {
            public static Node root = new Node();
     
            public List<Node> children { get; set;}
            public int level { get; set;}
            public string item { get; set;}
            public int qty { get; set; }
            public string rev { get; set;}
            public string status { get; set;}
            public string mostActive { get; set;}
            public Node() { }
            public Node(string filename)
            {
                XDocument doc = XDocument.Load(filename);
                XElement xmlRoot = doc.Root;
                GetNodesRecursive(root, xmlRoot);
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
        }
    }
