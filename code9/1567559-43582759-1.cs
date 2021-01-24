    string xml = @"<sample>
                            <a>123</a>
                            <a>45</a>
                            <a>67</a>
                            <a>890</a>
                        </sample>";
    XDocument xmlDoc = XDocument.Parse(xml);
    int value = 0;
    StringBuilder errorsSb = new StringBuilder();
    List<string> a_Nodes = new List<string>();
    xmlDoc.Descendants("a").Select(x => x.Value).ToList().ForEach(x =>
    {
         if (int.TryParse(x, out value))
              a_Nodes.Add(value.ToString("D3"));
         else
              errorsSb.AppendLine($"Value {value} is not a number");
         });
         string res = String.Join(string.Empty, a_Nodes);
         if (!string.IsNullOrWhiteSpace(errorsSb.ToString()))
         {
              // handle errors
         }
    }
