                String json = "{\"Items\": [{\"id\":1},{\"id\":2}]}";
                dynamic parse =  JsonConvert.DeserializeObject(json);
                XmlDocument doc = new XmlDocument();
                XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement root = doc.DocumentElement;
                doc.InsertBefore(xmlDeclaration, root);
                XmlElement element1 = doc.CreateElement(string.Empty, "root", string.Empty);
                doc.AppendChild(element1);
                XmlElement element2 = doc.CreateElement(string.Empty, "Items", string.Empty);
                element1.AppendChild(element2);
                foreach (var Items in parse.Items)
                {
                    XmlElement element22 = doc.CreateElement(string.Empty, "element", string.Empty);
                    element2.AppendChild(element22);
                    XmlElement element3 = doc.CreateElement(string.Empty, "id", string.Empty);
                    XmlText text1 = doc.CreateTextNode(Items.id.ToString());
                    element3.AppendChild(text1);
                    element22.AppendChild(element3);
                }
                
                MessageBox.Show(doc.InnerXml.ToString());
