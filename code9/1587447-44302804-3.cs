	private void mGetTnlFromXML(string oldTnl)
	{
		XDocument doc = XDocument.Load("sample.xml");
		foreach (var element in doc.Root.Elements("Object"))
		{
			var dynamic = element.Elements("bist").Where(x => x.Attribute("name").Value == "dynamic").First().Value;
			if (dynamic == oldTnl)
			{
				var tnl = element.Elements("bist").Where(x => x.Attribute("name").Value == "Tnl").First().Value;
				MessageBox.Show(tnl);
			};
		}
	}
