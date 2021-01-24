    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication48
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                columninfo.info = doc.Descendants("columninfo").Select(x => new columninfo() {
                    name = (string)x.Attribute("name"),
                    fieldList = columninfo.GetDictionary(x)
                }).ToList();
            }
        }
        public class columninfo
        {
            public static List<columninfo> info = new List<columninfo>();
            public string name {get;set;}
            public Dictionary<string,column> fieldList {get;set;}
            public static Dictionary<string,column> GetDictionary(XElement columninfo)
            {
                Dictionary<string,column> dict = new Dictionary<string,column>();
                foreach(XElement column in columninfo.Elements("column"))
                {
                    string fieldname = (string)column.Attribute("fieldname");
                    string _type = (string)column.Attribute("type");
                    string name = (string)column.Attribute("name");
                    column newCol;
                    string[] names;
                    switch(fieldname)
                    {
                        case "c1" :
                            names = name.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            newCol = new column() { name = names[0], format = _type, fieldname = fieldname };
                            dict.Add("c1", newCol);
                            newCol = new column() { name = names[1], format = _type, fieldname = fieldname };
                            dict.Add("c2", newCol);
                            break;
                        case "c3":
                            newCol = new column() { name = fieldname, format = _type, fieldname = fieldname };
                            dict.Add("c3", newCol);
                            break;
                        case "c4":
                            names = name.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            newCol = new column() { name = names[0], format = _type, fieldname = fieldname };
                            dict.Add("c4", newCol);
                            newCol = new column() { name = names[1], format = _type, fieldname = fieldname };
                            dict.Add("c5", newCol);
                            break;
                    }
                }
                return dict;
            }
        }
        public class column
        {
            public string name { get; set; }
            public string fieldname { get; set; }
            public string format { get; set; }
        }
    }
