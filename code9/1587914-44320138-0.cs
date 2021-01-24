	public static string RemoveAnythingInBrackets(string input)
	{
		if(string.IsNullOrEmpty(input))
		{
			return input;
		}
		StringBuilder result = new StringBuilder();
		Stack<char> bracket = new Stack<char>();
		foreach(char c in input)
		{
			if(c == '(')
			{
				bracket.Push(c);
			}
			else if(c == ')' && bracket.Peek() == '(')
			{
				bracket.Pop();
			}
			else if(!bracket.Any())
			{
				result.Append(c);
			}
		}
		return result.ToString();
	}
