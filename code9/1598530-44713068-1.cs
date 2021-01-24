    using System;
    using System.Linq;
    using System.Data;
    
    namespace JoinDatatablesConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt1 = new DataTable();
                dt1.Columns.Add("ID", typeof(string));
                DataTable dt2 = new DataTable();
                dt2.Columns.Add("ID", typeof(string));
                for(int i=1;i<5;i++)
                {
                    DataRow dr1 = dt1.NewRow();
                    dr1["ID"] = i + "A";
                    dt1.Rows.Add(dr1);
                    DataRow dr2 = dt2.NewRow();
                    dr2["ID"] = i + "A";
                    dt2.Rows.Add(dr2);
                }
                DataRow dr3 = dt2.NewRow();
                dr3["ID"] = "7A";
                dt2.Rows.Add(dr3);
    
                var commonData = (from f1 in dt1.AsEnumerable()
                                   join f2 in dt2.AsEnumerable()
                                   on f1.Field<string>("ID")
                                   equals f2.Field<string>("ID")
                                   select f1.Field<string>("ID"))
                                               .Distinct().ToList();
                Console.WriteLine("Common Data : ");
                foreach(var item in commonData)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Common Data Count : " + commonData.Count);
                Console.Read();
            }
        }
    }
