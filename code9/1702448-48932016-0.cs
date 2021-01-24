    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication23
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable("_InvTrans");
                dt.Columns.Add("Parent", typeof(string));
                dt.Columns.Add("Child", typeof(string));
                dt.Columns.Add("Name", typeof(string));
                dt.Rows.Add(new object[] { "Null", "A", "Alpha" });
                dt.Rows.Add(new object[] { "A", "B", "Bravo" });
                dt.Rows.Add(new object[] { "A", "C", "Charlie" });
                dt.Rows.Add(new object[] { "B", "E", "Echo" });
                dt.Rows.Add(new object[] { "B", "F", "Foxtrot" });
                dt.Rows.Add(new object[] { "C", "W", "Whiskey" });
                dt.Rows.Add(new object[] { "C", "H", "Hotel" });
                new Node(dt);
            }
        }
        public class Node
        {
            public static Node root = new Node();
            static DataTable dt = null;
            public List<Node> Child { get; set; }
            public string Name { get; set; }
            public string id { get; set; }
            public Node(){}
            public Node(DataTable dt)
            {
                Node.dt = dt;
                root.id = "Null";
                Add(root);
            }
            public static void Add(Node parent)
            {
                foreach (DataRow row in Node.dt.AsEnumerable().Where(x => x.Field<string>("Parent") == parent.id))
                {
                    Node child = new Node();
                    if (parent.Child == null) parent.Child = new List<Node>();
                    parent.Child.Add(child);
                    child.Name = row.Field<string>("Name");
                    child.id = row.Field<string>("Child");
                    Add(child);
                }
            }
        }
    }
