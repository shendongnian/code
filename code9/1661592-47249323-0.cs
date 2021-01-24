    string[] path=Directory.GetDirectories(textBox1.Text,"xml",SearchOption.AllDirectories)
    				.SelectMany(x=>Directory.GetFiles(x,"*.xml",SearchOption.AllDirectories)).ToArray();
    			Dictionary<string, string> dict = new Dictionary<string, string>();
    			var regex = new Regex(@"deqn(\d+)-(\d+)");
    			foreach (var file in path) {
    				dict.Clear();
    				XDocument doc = XDocument.Load(file, LoadOptions.PreserveWhitespace);
    				var x = from y in doc.Descendants("disp-formula")
    					let m = regex.Match(y.Attribute("id").Value)
    					where m.Success
    					select m;
    				foreach (var item in x)
    				{
    					var from = int.Parse(item.Groups[1].Value);
    					var to = int.Parse(item.Groups[2].Value);
    					for (int i = from; i <= to; i++)
    						dict.Add("rid=\"deqn" + i+"\"", "rid=\""+item.Value+"\"");
    					
    					foreach (KeyValuePair<string,string> element in dict) {
    						string text=File.ReadAllText(file);
    						text=text.Replace(element.Key,element.Value);
    						File.WriteAllText(file, text);
    					}
    					
    				}
    			}
    			MessageBox.Show("Done");
