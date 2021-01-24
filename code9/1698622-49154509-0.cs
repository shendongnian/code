	private string ShrinkOpenningHour(List<AgendaDay> agenda)
	{
		var temp = agenda.Where(x => x != null).ToArray();
		List<ShortAgendaDay> sum = new List<ShortAgendaDay>();
		for (var i = 0; i < temp.Count(); i++)
		{
			if (i == 0 || (temp[i - 1].heureAM == temp[i].heureAM && temp[i - 1].heurePM == temp[i].heurePM))
			{
				var existingEntry = sum.Where(x => x.AM == temp[i].heureAM && x.PM == temp[i].heurePM);
				if (existingEntry.Count() == 1)
				{
					existingEntry.First().Days.Add(temp[i].jour);
				}
				else
				{
					sum.Add(new ShortAgendaDay(new List<string>() { temp[i].jour }, temp[i].heureAM, temp[i].heurePM));
				}
			}
		}
		return string.Join(Environment.NewLine, sum.Select(x => FormatHorraire(x)));
	}
	
