    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create(FILENAME);
                while (!reader.EOF)
                {
                    if (reader.Name != "Table")
                    {
                        reader.ReadToFollowing("Table");
                    }
                    if (!reader.EOF)
                    {
                        XElement table = (XElement)XElement.ReadFrom(reader);
                        Table newTable = new Table() {
                            id = (int)table.Element("ID"),
                            no = (string)table.Element("Item_No"),
                            description = (string)table.Element("Description"),
                            remarks = (string)table.Element("Remarks"),
                            refNo = (string)table.Element("Ref_No")
                        };
                        Table.table.Add(newTable);
                    }
                }
     
            }
        }
        public class Table
        {
            public static List<Table> table = new List<Table>();
            public int id { get; set; }
            public string no { get; set; }
            public string description { get; set; }
            public string remarks { get; set; }
            public string refNo { get; set; }
        }
    }
        //<ID>1002065</ID>
        //<Item_No>0000043</Item_No>
        //<Description>Test2</Description>
        //<Remarks />
        //<Ref_No />
