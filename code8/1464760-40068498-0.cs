    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            static List<string> list = new List<string>();
            static DataTable dt = new DataTable();
            static void Main(string[] args)
            {
                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("Parent", typeof(int));
                dt.Columns["Parent"].AllowDBNull = true;
                dt.Columns.Add("Text", typeof(string));
                dt.Rows.Add(new object[] {1, null, "A"});
                dt.Rows.Add(new object[] {2, 1, "B"});
                dt.Rows.Add(new object[] {3, 2, "C"});
                dt.Rows.Add(new object[] {4, 3, "D"});
                dt.Rows.Add(new object[] {5, null, "E"});
                dt.Rows.Add(new object[] {6, 5, "F"});
                dt.Rows.Add(new object[] {7, 6, "G"});
                GetRecursiveChildren(null, new List<string>());
                foreach (string row in list)
                {
                    Console.WriteLine(row);
                }
                Console.ReadLine();
            }
            static void GetRecursiveChildren(int? parent, List<string> parents)
            {
                foreach (DataRow row in dt.AsEnumerable().Where(x => x.Field<int?>("Parent") == parent))
                {
                    string text = row.Field<string>("Text");
                    List<string> newParents = new List<string>();
                    newParents.AddRange(parents);
                    newParents.Add(text);
                    list.Add(string.Join(" > ",newParents));
                    int child = row.Field<int>("Id");
                    GetRecursiveChildren(child, newParents);
                }
            }
        }
        
    }
