    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication3 {
         public class Table
         {
            public static Table root = new Table();
            public List<Table> tables { get; set; }
            public List<string> headers {get; set;}
            public string title;
            public int rowspan;
            public int colspan;
            public int order;
            public Table()
            {
                headers = new List<string>();
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
                 var input =  new object[] {
                     new { title = "A", parent = "root"},
                     new { title = "B", parent = "root"},
                     new { title = "C", parent = "root"},
                     new { title = "B1", parent = "B"},
                     new { title = "B2", parent = "B"},
                     new { title = "C1", parent = "C"},
                     new { title = "C2", parent = "C"},
                     new { title = "B12", parent = "B1"},
                     new { title = "B21", parent = "B2"},
                 };
             }
         }    
    }
