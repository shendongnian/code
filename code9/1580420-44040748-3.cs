    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication3
    {
        public class Table
        {
            public static Tableheader headers { get; set; }
            public static int max;
            public class Tableheader
            {
                public string title;
                public List<Tableheader> subheaders;
                public int rowspan;
                public int colspan;
                public int order;
            }
            public void Add(DataTable data)
            {
                headers = new Tableheader();
                int level = 0;
                AddRecursive(data, headers, "", 0);
            }
            public void AddRecursive(DataTable data, Tableheader headers, string headerName, int level)
            {
                if (level > max) max = level;
                foreach (DataRow row in data.AsEnumerable().Where(x => x.Field<string>("parent") == headerName))
                {
                    if (headers.subheaders == null) headers.subheaders = new List<Tableheader>();
                    Tableheader newHeader = new Tableheader();
                    headers.subheaders.Add(newHeader);
                    string title = row.Field<string>("title");
                    newHeader.title = title;
                    AddRecursive(data, newHeader, title, level++);
                }
            }
            public int AddRecursiveSpan(int level, Tableheader header)
            {
                int cols = 0;
                foreach (Tableheader sHeader in header.subheaders)
                {
                    if (sHeader.subheaders == null)
                    {
                        sHeader.rowspan = max - level + 1;
                        sHeader.colspan = 1;
                        cols += 1;
                    }
                    else
                    {
                        sHeader.colspan += AddRecursiveSpan(level + 1, sHeader);
                        sHeader.rowspan = 1;
                        cols += sHeader.colspan;
                    }
                }
                return cols;
            }
        }
        class Program
        {
            public static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("title", typeof(string));
                dt.Columns.Add("parent", typeof(string));
                dt = new List<DataRow>() {
                     dt.Rows.Add(new object[] {"A",""}),
                     dt.Rows.Add(new object[] {"B",""}),
                     dt.Rows.Add(new object[] {"C",""}),
                     dt.Rows.Add(new object[] {"B1","B"}),
                     dt.Rows.Add(new object[] {"B2","B"}),
                     dt.Rows.Add(new object[] {"C1","C"}),
                     dt.Rows.Add(new object[] {"C2","C"}),
                     dt.Rows.Add(new object[] {"B21","B2"}),
                     dt.Rows.Add(new object[] {"B22","B2"})
                 }.CopyToDataTable();
                Table table = new Table();
                table.Add(dt);
                int level = 1;
                table.AddRecursiveSpan(level,Table.headers);
            }
        }
    }
