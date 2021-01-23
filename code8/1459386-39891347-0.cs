    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("A", typeof(string));
                dt.Columns.Add("B", typeof(string));
                dt.Columns.Add("C", typeof(string));
                dt.Rows.Add(new object[] {"A1", "B1","C1"});
                dt.Rows.Add(new object[] {"A1", "B1","C2"});
                dt.Rows.Add(new object[] {"A1", "B1","C3"});
                dt.Rows.Add(new object[] {"A1", "B2","C1"});
                dt.Rows.Add(new object[] {"A1", "B2","C2"});
                dt = dt.AsEnumerable()
                    .OrderBy(x => x.Field<string>("A"))
                    .ThenBy(x => x.Field<string>("B"))
                    .ThenBy(x => x.Field<string>("C"))
                    .CopyToDataTable();
                XElement data = new XElement("Data", new XElement("A", dt.AsEnumerable()
                    .GroupBy(g1 => g1.Field<string>("A")).Select(g1a =>  new object[] { 
                        new XElement("lable",(string)g1a.Key),
                        new XElement("B",
                            g1a.GroupBy(g2 => g2.Field<string>("B")).Select(g2b => new object[] {
                                new XElement("lable", (string)g2b.Key),
                                new XElement("C",
                                    g2b.Select(g3c => new XElement("lable", g3c.Field<string>("C"))
                                ))}
                        ))}
                )));
                
            }
        }
    }
