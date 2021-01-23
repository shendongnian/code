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
	public List<string> MakeRandColl(int size)
	{
		List<string> randChoices = choices;
		List<string> retVal = new List<string>();
		for(int i = 0; i < size; i++)
		{
			string temp = randChoices[rnd.Next(0, randChoices.Count)];
			retVal.Add(temp);
			randChoices.Remove(temp);
		}
		return retVal;
	}
	public void DeleteChoice(string choice)
	{
		choices.Remove(choice);
	}
