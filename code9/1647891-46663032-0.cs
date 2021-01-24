    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication7
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("Parent", typeof(int));
                dt.Columns.Add("Name", typeof(string));
                dt.Rows.Add(new object[] { 1, null, "Name (this is object 1)" });
                dt.Rows.Add(new object[] { 2, 1, "Name (this is element 1)" });
                dt.Rows.Add(new object[] { 3, 2, "Name (this is component 1)" });
                dt.Rows.Add(new object[] { 4, 2, "Name (this is component 2)" });
                dt.Rows.Add(new object[] { 5, 2, "Name (this is component 3)" });
                dt.Rows.Add(new object[] { 6, 1, "Name (this is element 2)" });
                dt.Rows.Add(new object[] { 7, 6, "Name (this is component 4)"});
                dt.Rows.Add(new object[] { 8, 1, "Name (this is element 3)" });
                dt.Rows.Add(new object[] { 9, null, "Name (this is object 2)" });
                dt.Rows.Add(new object[] { 10, 9, "Name (this is element 4)" });
                dt.Rows.Add(new object[] { 11, 10, "Name (this is component 5)" });
                dt.Rows.Add(new object[] { 12, 10, "Name (this is component 6)" });
                Node.RecursiveFill(dt, null, Node.root);
            }
        }
        public class Node
        {
            public static Node root = new Node();
            public List<Node> children { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public static void RecursiveFill(DataTable dt, int? parentId, Node parentNode)
            {
                foreach (DataRow row in dt.AsEnumerable().Where(x => x.Field<int?>("Parent") == parentId))
                {
                    Node newChild = new Node();
                    if (parentNode.children == null) parentNode.children = new List<Node>();
                    parentNode.children.Add(newChild);
                    newChild.id = row.Field<int>("Id");
                    newChild.name = row.Field<string>("Name");
                    RecursiveFill(dt, newChild.id, newChild);
                }
            }
        }
    }
