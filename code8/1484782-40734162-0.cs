	List<string> choices = new List<string>();
	Random rnd = new Random(DateTime.Now.Millisecond);
	public void PopulateChoices()
	{
		choices.Clear();
		for(char i = '0'; i < ':';i++)
		{
			for(char j = 'A'; j < 'C'; j++)
			{
				choices.Add(new string(new char[] { j, i }));
			}
		}
	}
	public string GetRandStr()
	{
		return choices[rnd.Next(0, choices.Count)];
	}
	public void DeleteChoice(string choice)
	{
		choices.Remove(choice);
	}
