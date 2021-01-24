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
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                string header = "<Research xmlns=\"http://www.rixml.org/2013/2/RIXML\"" +
                                                  " xmlns:rixmldt=\"http://www.rixml.org/2013/2/RIXML-datatypes\"" +
                                                  " xmlns:xsi=\"http://www.rixml.org/2013/2/RIXML\"" +
                                                  " researchID=\"BOGUS ID\"" +
                                                  " language=\"eng\"" +
                                                  " createdDateTime=\"" + System.DateTime.Now.Date.ToString() + "\"" +
                                                  " xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">";
                using (XmlWriter writer = XmlWriter.Create(FILENAME, settings))
                {
                    writer.WriteRaw(header) ;
                    XElement product = new XElement("Product", new XAttribute("productID", "asdf"));
                    XElement statusInfo = new XElement("StatusInfo", new object[] {
                            new XAttribute("currentStatusIndicatior", "Yes"),
                            new XAttribute("statusDateTime", System.DateTime.Now.Date.ToString()),
                            new XAttribute("statusType", "Published")
                    });
                    product.Add(statusInfo);
                    XElement source = new XElement("Source", new object[] {
                        new XElement("Organization", new object[] {
                            new XAttribute("type", "SellSideFirm"),
                            new XAttribute("primaryIndicatior", "Yes"),
                            new XElement("OrganizationID", new object[] {
                                new XAttribute("idType", "Bloomberg"),
                                "1234"
                            })
                        })
                    });
                    product.Add(source);
                    XElement organizationID = new XElement("OrganizationID", new object[] {
                        new XAttribute("idType", "FactSet"),
                        "rep_example"
                    });
                    product.Add(organizationID);
                    product.WriteTo(writer);
                    
                    writer.Flush();
                    writer.Close();
                }
            }
        }
    }
