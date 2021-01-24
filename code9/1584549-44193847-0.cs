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
                string xml1 =
                    "<States>" +
                       "<State>" +
                         "<State_ID>1</State_ID>" +
                         "<Job>" +
                           "<Job_ID>2</Job_ID><Name>Walk</Name>" +
                         "</Job>" +
                       "</State>" +
                     "</States>";
                string xml2 =
                    "<State>" +
                      "<State_ID>2</State_ID>" +
                      "<Job>" +
                        "<Job_ID>9</Job_ID><Name>Sprint</Name>" +
                      "</Job>" +
                    "</State>";
                XElement states = XElement.Parse(xml1);
                XElement newState = XElement.Parse(xml2);
                states.Add(newState);
            }
        }
    }
