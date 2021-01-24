        private static Product[] GetDetails(XmlDocument xmlDoc)
        {
            var result = new List<Product>();
            XmlNode tempNode;
            var nodeList = xmlDoc.GetElementsByTagName("Product");
            
            foreach(XmlNode node in nodeList)
            {
                var product = new Product();
                tempNode = node.FirstChild; //BasicFields
                if (tempNode != null)
                {
                    product.ProductCode = tempNode["ProductCode"].InnerText;
                    product.LongDescription = tempNode["LongDescription"].InnerText;
                }
                if (node.ChildNodes.Count > 1)
                {
                    tempNode = node.ChildNodes[1];
                    if (tempNode != null)
                    {
                        tempNode = tempNode.FirstChild; //Eancode
                        if (tempNode != null)
                        {
                            product.Barcode = tempNode.InnerText;
                        }
                    }
                }
                result.Add(product);
            }
            return result.ToArray();
        }
