    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication22
    {
        class Program
        {
            static void Main(string[] args)
            {
               string[] inputs = {
                         "Product1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1",
                         "Product2,9.00,1,1,1,9.00,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1"
                                 };
               List<List<string>> data = new List<List<string>>();
               foreach (string input in inputs)
               {
                   List<string> newData = input.Split(new char[] { ',' }).ToList();
                   data.Add(newData);
               }
               
               DataTable dt = new DataTable();
               int maxRows = data.Select(x => x.Count).Max();
               for(int column  = 0; column < data.Count; column++) 
               {
                   dt.Columns.Add(data[column][0], typeof(string));
                   dt.Columns[column].AllowDBNull = true;
               }
               for (int row = 0; row < maxRows; row++)
               {
                   dt.Rows.Add();
               }
               for (int column = 0; column < data.Count; column++)
               {
                   for (int row = 0; row < data[column].Count; row++)
                   {
                       dt.Rows[row][column] = data[column][row];
                   }
               }
               
            }
        }
     
    }
