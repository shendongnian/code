    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication71
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable("DepID") ;
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("NAME", typeof(string));
                dt.Columns.Add("PARENTID", typeof(int));
                dt.Rows.Add(new object[] { 1, "Dep1"});
                dt.Rows.Add(new object[] { 2, "Dep2"});
                dt.Rows.Add(new object[] { 3, "Dep3"});
                dt.Rows.Add(new object[] { 11, "A1", 1});
                dt.Rows.Add(new object[] { 12, "A2", 2});
                dt.Rows.Add(new object[] { 13, "A3", 1});
                dt.Rows.Add(new object[] { 14, "A4", 3});
                dt.Rows.Add(new object[] { 15, "A5", 3});
                dt.Rows.Add(new object[] { 21, "B1", 11});
                dt.Rows.Add(new object[] { 23, "B2", 14});
                dt.Rows.Add(new object[] { 24, "B3", 11});
                Node node = new Node();
                node.Load(dt);
            }
        }
        public class Node
        {
            public static Node root = new Node();
            public string name { get; set; }
            public int? id { get; set; }
            public List<Node> children { get; set; }
            public void Load(DataTable dt)
            {
                LoadRecursive(dt, null, root);
            }
            public void LoadRecursive(DataTable dt, int? parent, Node node)
            {
                foreach (DataRow row in dt.AsEnumerable().Where(x => x.Field<int?>("PARENTID") == parent))
                {
                    if (node.children == null) node.children = new List<Node>();
                    Node newChild = new Node();
                    node.children.Add(newChild);
                    newChild.name = row.Field<string>("NAME");
                    newChild.id  = row.Field<int>("ID");
                    LoadRecursive(dt, newChild.id, newChild);
                }
            }
        }
    }
 
