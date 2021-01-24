    //s is the Sheet
	WorksheetPart wsPart = workBookPart.GetPartById(s.Id) as WorksheetPart;
	foreach (var control in wsPart.ControlPropertiesParts)
	{
		string ctrlId = wsPart.GetIdOfPart(control);
		Console.Write("Control Id: {0}", ctrlId);
		if (control.FormControlProperties.Checked != null)
			Console.Write("Checked");
		Console.WriteLine();
	}
