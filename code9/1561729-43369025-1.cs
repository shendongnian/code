    private void XMltest()
	{
		string filePath = @"path to your xml";
		string[] myMovesArray = new string[2] {"Steamroller|2d8", "String Shot|4d10"};
		// Add a root to your xml since it wasn't shown in your example
		// NOTE: Remove these next two lines if your xml string does indeed have a root. 
		string xmlFragments = File.ReadAllText(filePath);
		string rootedXML = "<root>" + xmlFragments + "</root>";
		// load the xml
		XDocument xmlMoves = XDocument.Parse(rootedXML);
		// Loop through array and update associated element in xml with the new damage values
		foreach (var move in myMovesArray)
		{
			string moveName = move.Split('|')[0];
			string moveDamage = move.Split('|')[1];
			// Loop through xml and find the correct element by name
			foreach (XElement xmlMove in xmlMoves.Descendants("Move"))
			{
				if (xmlMove.Element("Name").Value == moveName)
				{
					xmlMove.Element("Damage").Value = moveDamage;
				}
			}
		}
		// Save back to xml file.
		xmlMoves.Save(filePath);
	}
