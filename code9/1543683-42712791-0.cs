      XmlDocument doc = new XmlDocument();
                    doc.LoadXml("yourxmldata");
        
                    XmlNodeList customers = doc.DocumentElement.SelectNodes("Customers");
        
                    foreach (XmlNode customer in customers)
                    {
                        XmlNodeList customerOrders = customer.SelectNodes("Orders");
        
                        string customername = customer["CustomerID"].InnerText;
                        
                        foreach (XmlNode customerOrder in customerOrders)
                        {
                            string orderid = customerOrder["OrderID"].InnerText;
                            string orderdate = customerOrder["OrderDate"].InnerText;
                        }
        
                    }
