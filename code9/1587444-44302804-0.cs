	private void mGetTnlFromXML(string oldTnl)
	{
		XDocument doc = XDocument.Load("sample.xml");
		var dynamic = doc.Root.Elements("bist").Where(x => x.Attribute("name").Value == "dynamic").First().Value;
		if (dynamic == oldTnl)
		{
			var tnl = doc.Root.Elements("bist").Where(x => x.Attribute("name").Value == "Tnl").First().Value;
			MessageBox.Show(tnl);
		};
	}
