   	var xe = System.Xml.Linq.XElement.Parse(customDate);
	if(DateTime.TryParseExact(xe.Element("BeginDate").Value, "MMMMyyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out var newDate))
	{
		xe.Element("BeginDate").Value = newDate.ToString("MM/dd/yyyy");
	}
