	public static string ReverseSentence(string input)
	{
		var word = new Queue<char>();
		var sentence = new Stack<IEnumerable<char>>( new [] { word } );
		foreach (char c in input)
		{
			if (c == ' ')
			{
				sentence.Push(" ");              
				sentence.Push( word = new Queue<char>() ); 
			}
			else
			{
				word.Enqueue(c);
			}
		}
		return new string( sentence.SelectMany( w => w ).ToArray() );
	}
