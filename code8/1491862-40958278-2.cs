    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                Node node = new Node(FILENAME);
                node.Print(node, 1);
                Console.ReadLine();
            }
        }
        public class Team
        {
            public string name { get; set; }
            public string id { get; set; }
        }
        public class Node
        {
            public Node child = null;
            public List<List<Team>> matches = new List<List<Team>>();
            public Node()
            {
            }
            public Node(string filename)
            {
                XmlReader reader = XmlTextReader.Create(filename);
                CreateTree(reader, this, false);
            }
            private void CreateTree(XmlReader reader, Node parent, Boolean isChild)
            {
                Boolean endElement = false;
                while (!reader.EOF && !endElement)
                {
                    if (!isChild)
                    {
                        reader.Read();
                    }
                    isChild = false;
                    if (!reader.EOF)
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element:
                                switch (reader.Name)
                                {
                                    case "Match": //We need to make a new match
                                        List<Team> match = new List<Team>();
                                        parent.matches.Add(match);
                                        CreateTree(reader, parent, false);
                                        break;
                                    case "Team": //We need to add a team!
                                        parent.matches.Last().Add(new Team() { 
                                            id = reader.GetAttribute("id"), 
                                            name = reader.ReadString().Trim()
                                        });
                                        if (reader.Name == "Match")
                                        {
                                            parent.child = new Node();
                                            CreateTree(reader, parent.child, true);
                                        }
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case XmlNodeType.EndElement:
                                //break out of while loop
                                endElement = true;
                                break;
                        }
                    }
                }
            }
            public void Print(Node node, int level)
            {
                foreach (List<Team> match in node.matches)
                {
                    Console.WriteLine("{0} Match", new string(' ',5 * level));
                    foreach (Team team in match)
                    {
                        Console.WriteLine("{0} Team : Name = '{1}', Id = '{2}'", new string(' ', (5 * level) + 3), team.name, team.id);
                    }
                }
                if (node.child != null)
                {
                    Print(node.child, level + 1);
                }
            }
        }
    }
