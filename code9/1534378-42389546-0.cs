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
                DataTable personTbl = new DataTable();
                personTbl.Columns.Add("Id", typeof(int));
                personTbl.Columns.Add("Name", typeof(string));
                personTbl.Columns.Add("Age", typeof(int));
                personTbl.Rows.Add(new object[] { 1, "Steve", 21});
                personTbl.Rows.Add(new object[] { 2, "Jack", 17});
                personTbl.Rows.Add(new object[] { 3, "Alcice", 25});
                personTbl.Rows.Add(new object[] { 4, "Harry", 14});
                DataTable personInfo = new DataTable();
                personInfo.Columns.Add("UId", typeof(int));
                personInfo.Columns.Add("Key", typeof(string));
                personInfo.Columns.Add("Value", typeof(string));
                personInfo.Rows.Add(new object[] { 1, "Height", "70"});
                personInfo.Rows.Add(new object[] { 2, "Height", "65"});
                personInfo.Rows.Add(new object[] { 2, "Eyes", "Blue"});
                personInfo.Rows.Add(new object[] { 4, "Height", "51"});
                personInfo.Rows.Add(new object[] { 3, "Hair", "Brown"});
                personInfo.Rows.Add(new object[] { 1, "Eyes", "Green"});
                List<string> infoType = personInfo.AsEnumerable().Select(x => x.Field<string>("Key")).Distinct().ToList();
                foreach (string type in infoType)
                {
                    personTbl.Columns.Add(type, typeof(string));
                }
                Dictionary<int, List<DataRow>> dict = personInfo.AsEnumerable().GroupBy(x => x.Field<int>("UId"), y => y)
                    .ToDictionary(x => x.Key, y => y.ToList());
                foreach (DataRow row in personTbl.AsEnumerable())
                {
                    int id = row.Field<int>("Id");
                    if(dict.ContainsKey(id))
                    {
                       List<DataRow> rowInfo = dict[id];
                       foreach (DataRow col in rowInfo)
                       {
                           row[(string)col["key"]] = col["Value"];
                       }
                    }
                }
            }
        }
    }
