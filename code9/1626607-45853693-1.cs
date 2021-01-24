                var ProjectPath = "the path to project folder";
                var input = new StringBuilder();
                input.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
			    input.AppendLine("<packages>");
    			using (var r = new StreamReader(ProjectPath + @"\project.json"))
    			{
    				var json = r.ReadToEnd();
    				dynamic array = JsonConvert.DeserializeObject(json);
    				foreach (var item in array.dependencies)
    				{
    					var xmlNode = item.ToString().Split(':');
    					input.AppendLine("<package id=" + xmlNode[0] + " version=" + xmlNode[1] + " />");
    				}
    			}
    			input.AppendLine("</packages>");
    
    			var doc = new XmlDocument();
    			doc.LoadXml(input.ToString());
    			doc.Save(ProjectPath + @"\packages.config");
                // After updating packages
                File.Delete(ProjectPath + @"\packages.config");
