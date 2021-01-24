	public ActionResult XmlData()
	{
		var doc = new XDocument(
			new XElement("Root",
				new XElement("Node1", 1),
				new XElement("Node2", 2)
			)
		);
		Response.ContentType = "text/xml";
		doc.Save(Response.Output);
		return new EmptyResult();
	}
