    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication43
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] input = { "This", "is","really", "great",", isn't it?"};
                KeyValuePair<int, int>[] startEndId = {
                    new KeyValuePair<int,int>(1,4),
                    new KeyValuePair<int,int>(2,3)
                };
                var seq = new XElement("seg", new object[] {
                    input[0],
                    new XElement("cf", new object[] {
                        new XAttribute("underline", "single"),
                        new XAttribute("startID", startEndId[0].Key),
                        new XAttribute("endID", startEndId[0].Value),
                        input[1],
                        new XElement("cf", new object[] {
                            new XAttribute("bold", "True"),
                            new XAttribute("startID", startEndId[1].Key),
                            new XAttribute("endID", startEndId[1].Value),
                            input[2],
                        }),
                        input[3],
                    }),
                    input[4]
                });
            }
        }
    }
