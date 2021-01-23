    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication16
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create(FILENAME);
                while(!reader.EOF)
                {
                    if(reader.Name != "Orders")
                    {
                        reader.ReadToFollowing("Orders");
                    }
                    if(!reader.EOF)
                    {
                        XElement order = (XElement)XElement.ReadFrom(reader);
                        int OrderID = (int)order.Element("OrderID");
                        string CustomerID = (string)order.Element("CustomerID");
                        int EmployeeID = (int)order.Element("EmployeeID");
                    }
                } 
            }
        }
    }
