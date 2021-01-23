    public class DocumentumServices
	{
		public string href { get; set; }
		public Dictionary<string, List<string>> hints { get; set; }
	}
	// ...
    
	var ds = JObject.Parse(result);
	var list = (from doc in ds["resources"]
				select doc.Values().ToDictionary(k => ((JProperty)k).Name, v => v.Children().First()) into gr 
				select new DocumentumServices() {
					href = gr["href"].ToString(),
					hints = (from hint in gr["hints"]
							 select new {
								Key = hint.Path.Substring(hint.Path.LastIndexOf('.')+1),
								Value = hint.Children().First().Select(x => x.ToString()).ToList()
							}).ToDictionary(k => k.Key, v => v.Value)
				}).ToList();
