    using (FileStream fileStramWrite = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))   
     using (StreamReader streamReader = new StreamReader(fileStramWrite))
        				{
        					var xdoc = XDocument.Load(streamReader);
                            var xElement = xdoc.Element("memberlist");
        					var xElement2 = xElement.Element("member");
                            var name = xElement2.Element("name").Value;
        					var status = xElement2.Element("status").Value;
        				}
