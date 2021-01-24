            XDocument xmlDocNew = XDocument.Parse(xElementCreateRoot.ToString());
            XElement xElementSelectRootNew = xmlDocNew.XPathSelectElement("//root");
            XElement xElementCreateRootNew = new XElement(new XElement("root"));
            IEnumerable<XElement> lstOFCatogoryNew = xElementSelectRootNew.XPathSelectElements("//category").OrderBy(r => r.Value).ToList();
            List<Class1> lstClass1 = new List<Class1>();
            int intClassIndexCounter = 0;
            foreach (var x in lstOFCatogoryNew)
            {
                if (x.Parent.Name.ToString() == "Product")
                {
                    if (lstClass1.Count() > 0)
                    {
                        if (lstClass1[lstClass1.Count()-1].SujectName.Trim().ToString() == ((XElement)x.Parent.FirstNode).Value.Trim().ToString())
                        {
    
                            var xsDoc = new XDocument(new XElement(XElement.Parse(x.Parent.ToString())));
    
                            XElement xElementSelectProduct = xsDoc.XPathSelectElement("//Product");
    
                            xElementCreateRootNew.Elements("Product").Last().Add(xElementSelectProduct.XPathSelectElement("//category"));
                       
    
                            lstClass1.Add(new Class1(((XElement)x.Parent.FirstNode).Value.Trim().ToString(),//subject title
                                ((XElement)x.FirstNode).Value.Trim().ToString(),//code-id
                                x.Parent.ToString().Trim()));//product set
    
                            intClassIndexCounter++;
                        }
                        else
                        {
                            xElementCreateRootNew.Add(x.Parent);
                            lstClass1.Add(new Class1(((XElement)x.Parent.FirstNode).Value.Trim().ToString(),//subject title
                                ((XElement)x.FirstNode).Value.Trim().ToString(),//code-id
                                x.Parent.ToString().Trim()));//product set
    
                            intClassIndexCounter++;
                        }
                    }
                    else
                    {
                        xElementCreateRootNew.Add(x.Parent);
                        lstClass1.Add(new Class1(((XElement)x.Parent.FirstNode).Value.Trim().ToString(),//subject title
                            ((XElement)x.FirstNode).Value.Trim().ToString(),//code-id
                            x.Parent.ToString().Trim()));//product set
    
                        intClassIndexCounter++;
                    }
                }
                else
                {
                    xElementCreateRootNew.Add(x);
                }
            }
