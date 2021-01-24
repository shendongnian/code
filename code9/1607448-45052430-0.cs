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
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                DataTable dt = new DataTable("Communications");
                string[] columnNames = doc.Descendants("ParamName").Select(x => (string)x).Distinct().ToArray();
                dt.Columns.Add("ModelNumber", typeof(string));
                foreach (string colName in columnNames)
                {
                    dt.Columns.Add(colName, typeof(string));
                }
                var models = doc.Descendants("Communications").GroupBy(x => (string)x.Element("ModelNumber")).ToList();
                foreach(var model in models)
                {
                    var orderedModel = model.Select(x => new { 
                        paramCount = x.Descendants("ParamValue").Count(), 
                        parmName = (string)x.Element("ParamName"),
                        parms = x.Descendants("ParamValue").Select(y => (string)y).ToList()
                    }).OrderByDescending(x => x.paramCount).ToList();
                    for (int parm = 0; parm < orderedModel.FirstOrDefault().paramCount; parm++)
                    {
                        DataRow newRow = dt.Rows.Add();
                        newRow["ModelNumber"] = model.Key;
                        foreach(var col in orderedModel)
                        {
                            if (col.paramCount > parm)
                            {
                                newRow[col.parmName] = col.parms[parm];
                            }
                        }
                    }
                }
            }
        }
    }
