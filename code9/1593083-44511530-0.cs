    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                FolderTree tree = new FolderTree();
                tree.BuildTree();
            }
        }
        public class FolderTree
        {
            public static FolderTree root { get; set; }
            public int id { get; set; }
            public List<FolderTree> children { get; set; }
            static DataTable dt { get; set; }
            public void BuildTree()
            {
                dt = new DataTable();
                dt.Columns.Add("FolderID", typeof(int));
                dt.Columns.Add("PARENT_ID", typeof(int));
                dt.Rows.Add(new object[] { 1, 0 });
                dt.Rows.Add(new object[] { 2, 0 });
                dt.Rows.Add(new object[] { 3, 2 });
                dt.Rows.Add(new object[] { 4, 1 });
                dt.Rows.Add(new object[] { 5, 0 });
                dt.Rows.Add(new object[] { 6, 4 });
                dt.Rows.Add(new object[] { 7, 3 });
                dt.Rows.Add(new object[] { 8, 0 });
                dt.Rows.Add(new object[] { 9, 1 });
                dt.Rows.Add(new object[] { 10, 8 });
                dt.Rows.Add(new object[] { 11, 0 });
                dt.Rows.Add(new object[] { 12, 11 });
                dt.Rows.Add(new object[] { 13, 0 });
                dt.Rows.Add(new object[] { 14, 0 });
                dt.Rows.Add(new object[] { 15, 2 });
                root = new FolderTree();
                BuildTreeRecursive(0, root);
            }
            void BuildTreeRecursive(int parentID, FolderTree parent)
            {
                parent.id = parentID;
                foreach(DataRow folder in dt.AsEnumerable().Where(x => x.Field<int>("PARENT_ID") == parentID))
                {
                    if (parent.children == null)
                    {
                        parent.children = new List<FolderTree>();
                    }
                    FolderTree child = new FolderTree();
                    int childID = folder.Field<int>("FolderID");
                    parent.children.Add(child);
                    BuildTreeRecursive(childID, child);
                }
            }
        }
    }
