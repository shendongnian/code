      public static class XMLOutput
        {
            public static void XMLProductOutput(product product, string path) {
    
                using (XmlWriter xmlWriter = XmlWriter.Create(path))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("Envelope");
                    xmlWriter.WriteStartElement("ProductMasterUpdate");
                    xmlWriter.WriteElementString("ProdCode", product.ProdCode.ToString());
                    xmlWriter.WriteElementString("Length", product.Length.ToString() ?? String.Empty.ToString());
                    xmlWriter.WriteElementString("Width", product.Width.ToString() ?? String.Empty.ToString());
                    xmlWriter.WriteElementString("Lip", product.Height.ToString() ?? String.Empty.ToString());
                    xmlWriter.WriteElementString("MatCat", product.MATCATEGORY.ToString());
                    xmlWriter.WriteElementString("UPC1", product.UPCCODE ?? String.Empty.ToString());
                    xmlWriter.WriteElementString("UPC2", product.UPCCODE2 ?? String.Empty.ToString());
                    xmlWriter.WriteElementString("UPC3", product.UPCCODE3 ?? String.Empty.ToString());
                    xmlWriter.WriteElementString("PLU", product.PLU ?? String.Empty.ToString());
                    xmlWriter.WriteElementString("ManufacturerCode", product.ManufacturerCode.ToString() ?? String.Empty.ToString());
                    xmlWriter.WriteElementString("Specs", product.SpecComments ?? String.Empty.ToString());
    
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                }
            }
        }
