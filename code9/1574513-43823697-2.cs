    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication50
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Category", typeof(string));
     
                string[] data = { "Main-A2-11", "Main-A2-113", "Main-A2-114", "Main-A2-115",
                                  "Third-F-L-56", "Third-F-L-566", "Third-F-L-567",
                                  "Second-F-L-5", "Second-F-L-55"
                                };
                foreach (string d in data)
                {
                    dt.Rows.Add(new object[] { d });
                }
                dt = dt.AsEnumerable().OrderBy(x => x, new SortRecord("Category")).CopyToDataTable();
            }    
        }
        public class SortRecord : IComparer<DataRow> 
        {
            public string name { get; set; }
            public SortRecord(string name)
            {
                this.name = name;
            }
            public int Compare(DataRow  rowA, DataRow rowB)
            {
                string[] rowSplitArrayA = rowA.Field<string>(name).Split(new char[] { '-' });
                string[] rowSplitArrayB = rowB.Field<string>(name).Split(new char[] { '-' });
                int lenA = rowSplitArrayA.Length;
                int lenB = rowSplitArrayB.Length;
                int len = Math.Min(lenA, lenB);
                int i = 0;
                for(i = 0; i < len; i++)
                {
                    if (rowSplitArrayA[i] != rowSplitArrayB[i])
                        return rowSplitArrayA[i].CompareTo(rowSplitArrayB[i]);
                }
                if(lenA == lenB) return  0;
                if (lenA < lenB) return -1;
                return 1;
            }
        }
       
    }
