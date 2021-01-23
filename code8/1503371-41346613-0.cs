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
            static void Main(string[] args)
            {
                string xml = 
                    "<Root>" +
                    "<WritableKeyValuePairOfKeyContraenteArrayOfAddress>" +
                       "<key>" +
                          "<KeyContaente>123456</KeyContaente>" +
                       "</key>" +
                       "<value>" +
                          "<Address>Maple road 12</Address>" +
                       "</value>" +
                       "<value>" +
                          "<Address>Oak street 71</Address>" +
                       "</value>" +
                    "</WritableKeyValuePairOfKeyContraenteArrayOfAddress>" +
                    "</Root>";
                XElement elements = XElement.Parse(xml);
                Dictionary<string, List<string>> dict = elements.Descendants("WritableKeyValuePairOfKeyContraenteArrayOfAddress").Select(x => new {
                    key = (string)x.Descendants("KeyContaente").FirstOrDefault(),
                    values = x.Descendants("Address").Select(y => (string)y).ToList()
                }).GroupBy(x => x.key, y => y.values)
                .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
    }
