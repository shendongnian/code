	public static string ReverseSentence(string input)
	{
		//Start with a sentence containing one initial word
		var word = new Queue<char>();
		var sentence = new Stack<IEnumerable<char>>( new [] { word } );
			
		foreach (char c in input)
		{
			if (c == ' ')
			{
				//Add a space to the sentence and start a new word
				sentence.Push(" ");              
				sentence.Push( word = new Queue<char>() ); 
			}
			else
			{
				//Add the character to the last word in the sentence
				word.Enqueue(c);
			}
		}
			
		//Enumerate over all words to compose a char array and string
		return new string( sentence.SelectMany( w => w ).ToArray() );
	}
