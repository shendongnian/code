	private string FormatHorraire(ShortAgendaDay x)
	{
		string days = string.Join(" - ", new String[] { x.Days.First(), x.Days.Last() }.Where(ar => ar != null).Distinct());
		string hour = FormatHorraire(x.AM, x.PM);
		return days + " : " + hour;
	}
	
	private string FormatHorraire(string am, string pm)
	{
		return string.Join(" / ", new string[] { am, pm }.Where(y => !string.IsNullOrWhiteSpace(y) && y.Length > 7).Select(y => y.Insert(2, "H").Insert(8, "H")));
	}
