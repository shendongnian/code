	private IEnumerable<Image> GetImagesFromXml(string xml)
	{
		XDocument doc = XDocument.Parse(xml);
		var ns = doc.Root.Name.Namespace;
		var images = doc.Descendants(ns + "part").Where(a => a.Attribute(ns + "contentType") != null && a.Attribute(ns + "contentType").Value.Contains("image"))
		.Select(a => new { Name = a.Attribute(ns + "name").Value, Type = a.Attribute(ns + "contentType").Value, D64 = a.Descendants(ns + "binaryData").First().Value, Compression = a.Attribute(ns + "compression").Value });
		return images.Select(i => Image.FromStream(new MemoryStream(Convert.FromBase64String(i.D64)), false, false));
	}
