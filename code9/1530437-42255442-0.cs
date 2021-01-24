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
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof (int));
                dt.Columns.Add("name", typeof (string));
                dt.Columns.Add("trID", typeof (int));
                dt.Columns.Add("trName", typeof (string));
                dt.Rows.Add(new object[] { 1,"a", 5,"x"});
                dt.Rows.Add(new object[] { 2,"b", 6,"y"});
                dt.Rows.Add(new object[] { 2,"c", 7,"z"});
                dt.Rows.Add(new object[] { 3,"d", 8,"m"});
                dt.Rows.Add(new object[] { 3,"e", 9,"n"});
                dt.Rows.Add(new object[] { 4,"f", 510,"0"});
                var groups = dt.AsEnumerable().GroupBy(x => x.Field<int>("id")).ToList();
                 
            }
        }
     
    }
