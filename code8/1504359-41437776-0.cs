    foreach (XElement node in loadedData.Descendants())
                {
                    if ((node.Parent != null && (node.Parent.Name.LocalName == "product")))
                    {
                        if ((node.Parent != null && node.Parent.Name.LocalName == "Transactions"))
                        { }
                    }
                    
                    else
                    {
                   //some code here
                    }
                }
