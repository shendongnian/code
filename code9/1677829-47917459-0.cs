	void Main()
	{
		var filename ="Your File.html";
		var instance = new Class1();
		var document = instance.HTMGenerator();
		document.Save(filename);
		Process.Start(filename);
	}
	
	public class Class1
	{
		public XDocument HTMGenerator()
		{
			string html = "<p>test</p>";
	
			var xDocument =
				new XDocument(
					new XDocumentType("html", null, null, null),
					new XElement(
						"html",
						new XElement("head"),
						new XElement(
							"body",
							XElement.Parse(html))));
	
			return xDocument;
		}
	}
