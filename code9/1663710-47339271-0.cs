    using (FileStream fileStramWrite = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))   
     using (StreamReader streamReader = new StreamReader(fileStramWrite))
        				{
        					List<XmlModel> reslt = new List<XmlModel>();
        					XDocument xdoc = XDocument.Load(streamReader);
                            XDocument xElement = xdoc.Element("memberlist");
        					XDocument xElement2 = xElement.Element("member");
                            var name = xElement2.Element("name").Value;
        					var status = xElement2.Element("status").Value;
        				}
