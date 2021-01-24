    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            static DataTable dt = null;
            static void Main(string[] args)
            {
                dt = new DataTable();
                dt.Columns.Add("_id", typeof(int));
                dt.Columns.Add("_name", typeof(string));
                dt.Columns.Add("_id_parent", typeof(int));
                dt.Rows.Add(new object[] {1, "item1",0});
                dt.Rows.Add(new object[] {2, "item2",1});
                dt.Rows.Add(new object[] {3, "item3",1});
                dt.Rows.Add(new object[] {4, "item4",2});
                dt.Rows.Add(new object[] {5, "item5",2});
                dt.Rows.Add(new object[] {6, "item6",3});
                dt.Rows.Add(new object[] {7, "item7",5});
                Node.root.id = 0;
                Node.MakeTree(dt, Node.root);
            }
        }
        public class Node
        {
            public static Node root = new Node();
            public string name { get; set; }
            public int id { get; set; }
            public List<Node> children { get; set; }
            public static void MakeTree(DataTable dt, Node parent)
            {
                foreach(DataRow row in dt.AsEnumerable().Where(x => x.Field<int>("_id_parent") == parent.id))
                {
                    if (parent.children == null)
                    {
                        parent.children = new List<Node>();
                    }
                    Node newNode = new Node();
                    newNode.name = row.Field<string>("_name");
                    newNode.id = row.Field<int>("_id");
                    parent.children.Add(newNode);
                    MakeTree(dt, newNode);
                }
            }
        }
    }
