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
                int templateId = 123;
                string custName = "john";
                string custEmail = "abc@def.com";
                string txtPropAddr = "123 main st.";
                string txtPropCity = "city";
                int txtPropZip = 12345;
                decimal txtPayment = 1.00M;
                string repName = "john";
                string repEmail = "abc@def.com";
                string requestBody = "<envelopeDefinition xmlns=\"http://www.docusign.com/restapi\"></envelopeDefinition>";
                XElement requestBodyElement = XElement.Parse(requestBody);
                XNamespace ns = requestBodyElement.GetDefaultNamespace();
                requestBodyElement.Add(new object[] {
                    new XElement(ns + "status", "sent"),
                    new XElement(ns + "emailSubject", "Just A Test"),
                    new XElement(ns + "templateId", templateId),
                    new XElement(ns + "templateRoles", new object[] {
                        new XElement(ns + "templateRole", new object[] {
                            new XElement(ns + "name", custName), 
                            new XElement(ns + "email", custEmail),
                            new XElement(ns + "roleName", "Customer"),
                            new XElement(ns + "tabs", new object[] {
                                new XElement(ns + "textTabs", new object[] {
                                    new XElement(ns + "text", new object[] {
                                        new XElement(ns + "tabLabel", "\\*txtPropAddr"),
                                        new XElement(ns + "value", txtPropAddr)
                                    }),
                                    new XElement(ns + "text", new object[] {
                                        new XElement(ns + "tabLabel", "\\*txtPropCity"),
                                        new XElement(ns + "value", txtPropCity.TrimEnd())
                                    }),
                                    new XElement(ns + "text", new object[] {
                                        new XElement(ns + "tabLabel", "\\*txtPropZip"),
                                        new XElement(ns + "value", txtPropZip)
                                    })
                                }),
                                new XElement(ns + "numberTabs",
                                    new XElement(ns + "number", new object[] {
                                        new XElement(ns + "fontColor", "DarkRed"),
                                        new XElement(ns + "locked", true),
                                        new XElement(ns + "tabLabel", "PaymentCustom"),
                                        new XElement(ns + "value", txtPayment)
                                    })
                                })
                            })
                        }),
                        new XElement(ns + "templateRole", new object[] {
                            new XElement(ns + "name", repName), 
                            new XElement(ns + "email", repEmail),
                            new XElement(ns + "roleName", "SalesRep")
                        })
                    })
                });
                XElement paymentDetails = new XElement(ns + "paymentDetails",
                    new XElement(ns + "paymentDetails",
                        new XElement(ns + "lineItems",
                            new XElement(ns + "paymentLineItem", new object[] {
                                new XElement(ns + "amountReference", "PaymentCustom"), 
                                new XElement(ns + "description", "test string 1"),
                                new XElement(ns + "itemCode", "test string 2"),
                                new XElement(ns + "name", "test string 3")
                            })
                        )
                   )
                );
                requestBodyElement.Add(paymentDetails);
            }
        }
    }
