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
                dt.Columns.Add("StudentName", typeof(string));
                dt.Columns.Add("Class", typeof(string));
                dt.Columns.Add("GPA", typeof(decimal));
                dt.Columns.Add("Course", typeof(string));
                dt.Columns.Add("CourseNumber", typeof(int));
                dt.Columns.Add("FinalGrade", typeof(string));
                dt.Columns.Add("CSCIGPA", typeof(decimal));
                dt.Rows.Add(new object[] {"D, Kara","SR",3.8,"CSCI4220",4220,"A",3.9});
                dt.Rows.Add(new object[] {"D, Kara","SR",3.8,"CSCI3110",3110,"A",3.9});
                dt.Rows.Add(new object[] {"R, Cisco","JR",3.1,"CSCI3010",3030,"B",3.4});
                dt.Rows.Add(new object[] {"R, Cisco","JR",3.1,"CSCI2070",2070,"C",3.4});
                dt.Rows.Add(new object[] {"R, Cisco","JR",3.1,"CSCI3030",3030,"B",3.4});
                dt.Rows.Add(new object[] {"A, Barry","FR",4.0,"CSCI1010",1010,"A",4.0});
                dt.Rows.Add(new object[] {"A, Barry","FR",4.0,"CSCI2010",2010,"A",4.0});
                dt.Rows.Add(new object[] {"Q, Oliver","SO",2.7,"CSCI2020",2010,"C",2.8});
                dt.Rows.Add(new object[] {"Q, Oliver","SO",2.7,"CSCI2020",2010,"C",2.8});
                dt.Rows.Add(new object[] {"Q, Oliver","SO",2.7,"CSCI2030",2030,"C",2.8});
                dt.Rows.Add(new object[] { "H, Roy", "SO", 3.8, "CSCI2020", 2020, "A", 3.7 });
                var myquery = dt.AsEnumerable()
                   .OrderBy(x => x.Field<string>("Class")).ThenByDescending(x => x.Field<decimal>("GPA")).ThenByDescending(x => x.Field<decimal>("CSCIGPA")).ToList();
            }
        }
    }
