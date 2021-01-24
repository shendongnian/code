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
                dt = dt.AsEnumerable().OrderBy(x => new SortRecord(x,"Category")).CopyToDataTable();
            }
        }
        public class SortRecord : IComparer<SortRecord >, IComparable
        {
            string[] rowSplitArray;
            int length = 0;
            public SortRecord(DataRow x, string name)
            {
                rowSplitArray = x.Field<string>(name).Split(new char[] { '-' });
                length = rowSplitArray.Length;
            }
            public int Compare(SortRecord  rowA, SortRecord rowB)
            {
                int len = Math.Min(rowA.length, rowB.length);
                for (int i = 0; i < len; i++)
                {
                    if (rowA.rowSplitArray[i] != rowB.rowSplitArray[i])
                        return rowA.rowSplitArray[i].CompareTo(rowB.rowSplitArray[i]);
                }
                if (rowA.length == rowB.length) return 0;
                if (rowA.length < rowB.length) return -1;
                return 1;
            }
            public int CompareTo(object row)
            {
                return Compare(this, (SortRecord) row);
            }
        }
    }
