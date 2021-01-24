	public static IEnumerable<string> ModifyNames(IEnumerable<string> names)
    {
        int index = 1;
        
        foreach (string name in names)
        {
			yield return name + index;
			index++;
        }
    }
