    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public static DataTable inputTable = new DataTable();
            public static DataTable outputTable = new DataTable();
            public static List<List<KeyValuePair<string,string>>> parseRows = new List<List<KeyValuePair<string,string>>>();
            public Form1()
            {
                InitializeComponent();
                inputTable.Columns.Add("Index", typeof(string));
                inputTable.Columns.Add("Title", typeof(string));
                inputTable.Rows.Add(new string[] { "01", "EQUITY" });
                inputTable.Rows.Add(new string[] { "01-001", "MR. J" });
                inputTable.Rows.Add(new string[] { "01-002", "MR. K" });
                inputTable.Rows.Add(new string[] { "01-003", "MR. L" });
                inputTable.Rows.Add(new string[] { "01-004", "MR. M" });
                inputTable.Rows.Add(new string[] { "02", "TRADE CREDITORS" });
                inputTable.Rows.Add(new string[] { "02-001", "TRADE CREDITORS RAW MATERIALS" });
                inputTable.Rows.Add(new string[] { "02-001-0001", "TRADE CREDITORS ITEM X" });
                inputTable.Rows.Add(new string[] { "02-001-0001-001", "MR. A" });
                inputTable.Rows.Add(new string[] { "02-001-0001-002", "MR. B" });
                inputTable.Rows.Add(new string[] { "02-001-0001-003", "MR. C" });
                inputTable.Rows.Add(new string[] { "02-001-0001-004", "MR. D" });
                inputTable.Rows.Add(new string[] { "02-002", "TRADE CREDITORS PACKING MATERIALS" });
                inputTable.Rows.Add(new string[] { "02-002-0001", "MR. X" });
                inputTable.Rows.Add(new string[] { "02-002-0002", "MR. Y" });
                inputTable.Rows.Add(new string[] { "02-002-0003", "MR. Z" });
     
                RecursiveParseTable("", new List<KeyValuePair<string,string>>());
                //get maximum number of columns for table
                int maxColumns = parseRows.Select(x => x.Count()).Max();
                //create output table
                for (int i = 0; i < maxColumns; i++)
                {
                    outputTable.Columns.Add("Index " + (i + 1).ToString(), typeof(string));
                    outputTable.Columns.Add("Title " + (i + 1).ToString(), typeof(string));
                }
                foreach(List<KeyValuePair<string, string>> row in parseRows)
                {
                    DataRow newRow = outputTable.Rows.Add();
                    int colIndex = 0;
                    foreach (KeyValuePair<string, string> col in row)
                    {
                        newRow[colIndex] = col.Key;
                        newRow[colIndex + 1] = col.Value;
                        colIndex += 2;
                    }
                    
                }
                dataGridView1.DataSource = outputTable;
            }
            public static void RecursiveParseTable(string index, List<KeyValuePair<string, string>> titles)
            {
                List<DataRow> children = null;
                if (index.Length == 0)
                {
                    children = inputTable.AsEnumerable().Where(x => !x.Field<string>("Index").Contains("-")).ToList();
                }
                else
                {
                    int startParseIndex = index.Length + 1;  //only get child indexes with no dash so you don't get grandchildren
                    children = inputTable.AsEnumerable().Where(x => 
                        (x.Field<string>("Index").StartsWith(index + "-")) && 
                        (!x.Field<string>("Index").Substring(startParseIndex).Contains("-"))
                        ).ToList();
                }
                children = children.OrderBy(x => x.Field<string>("Index")).ToList();
                if (children.Count == 0)
                {
                    parseRows.Add(titles);
                }
                else
                {
                    foreach (DataRow child in children)
                    {
                        List<KeyValuePair<string, string>> childTitles = new List<KeyValuePair<string, string>>();
                        childTitles.AddRange(titles);
                        string childIndex = child.Field<string>("Index");
                        string childTitle = child.Field<string>("Title");
                        childTitles.Add(new KeyValuePair<string, string>(childIndex, childTitle));
                        RecursiveParseTable(childIndex, childTitles);
                    }
                }
            }
        }
     
    }
