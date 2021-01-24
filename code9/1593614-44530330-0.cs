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
                    "<sdfsdfsd>" +
                        "<blah>" +
                        "<mypath>D:\\my\\old\\path\\aaa</mypath>" +
                        "</blah>" +
                        "<blah>" +
                        "<mypath>D:\\my\\old\\path\\bbb</mypath>" +
                        "</blah>" +
                        "<blah>" +
                        "<mypath>D:\\my\\old\\path\\ccc</mypath>" +
                        "</blah>" +
                    "</sdfsdfsd>";
                XElement element = XElement.Parse(xml);
                foreach(XElement mypath in  element.Descendants("mypath"))
                {
                    mypath.SetValue(((string)mypath).Replace("old","new"));
                }
            }
        }
    }
