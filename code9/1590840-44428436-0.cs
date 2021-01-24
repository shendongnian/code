    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    using System.Globalization;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Time", typeof(DateTime));
                dt.Columns.Add("Results", typeof(string));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Col 4", typeof(string));
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Col 5", typeof(string));
                dt.Columns.Add("Status", typeof(string));
             //<Cell columnid="1" InSeconds="1496227357">31/05/2017  10:42:37 AM</Cell>
             //<Cell columnid="2"> Error</Cell>
             //<Cell columnid="3">  Microsoft-Windows-CAPI2</Cell>
             //<Cell columnid="4">  N/A</Cell>
             //<Cell columnid="5"> 513</Cell>
             //<Cell columnid="6"> N/A</Cell>
             //<Cell columnid="7">Access is denied.. </Cell>
                XDocument doc = XDocument.Load(FILENAME);
                foreach (XElement sectionItem in doc.Descendants("SectionItem"))
                {
                    XElement[] cells = sectionItem.Elements("Cell").ToArray();
                    DataRow newRow = dt.Rows.Add(new object[] {
                       DateTime.ParseExact( (string)cells[0],"dd/MM/yyyy  hh:mm:ss tt", CultureInfo.InvariantCulture),
                       ((string)cells[1]).Trim(),
                       ((string)cells[2]).Trim(),
                       ((string)cells[3]).Trim(),
                       (int)cells[4],
                       ((string)cells[5]).Trim(),
                       ((string)cells[6]).Trim(),
                    });
                }
                dt = dt.AsEnumerable().OrderBy(x => x.Field<string>("Name")).CopyToDataTable();
               
            }
        }
     
    }
