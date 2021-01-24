    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication3 {
         public class Table
         {
             public static Tableheader headers { get; set;}
             public class Tableheader
             {
                 public string title;
                 public List<Tableheader> subheaders;
                 public int rowspan;
                 public int colspan;
                 public int order;
                 public int max;
             }
             public void Add(DataTable data)
             {
                 headers = new Tableheader();
                 AddRecursive(data, headers, "", 1);
             }
             public void AddRecursive(DataTable data, Tableheader headers, string headerName, int level)
             {
                 if(level > max) max = level;
                 headers.subheaders = new List<Tableheader>();
                 foreach (DataRow  row in data.AsEnumerable().Where(x => x.Field<string>("parent") == headerName))
                 {
                     Tableheader newHeader = new Tableheader();
                     headers.subheaders.Add(newHeader);
                     string title = row.Field<string>("title");
                     newHeader.title = title;
                     AddRecursive(data, newHeader, title, level ++);
                 }
             }
         }
         class Program
         {
             static int level;
             static int max;
             static int count;
             public static int rowspan(int level)
             {
                 int x;
                 if (count != 0)
                 {
                     x = 1;
                 }
                 else
                 {
                     x = (max - level) + 1;
                 }
                 return x;
             }
             public static int colspan()
             {
                 int y = 1;
                 if (count != 0)
                 {
                     y = count;
                 }
                 return y;
             }
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
                     dt.Rows.Add(new object[] {"B12","B1"}),
                     dt.Rows.Add(new object[] {"B21","B2"})
                 }.CopyToDataTable();
                 Table table = new Table();
                 table.Add(dt);
             }
         }    
    }
