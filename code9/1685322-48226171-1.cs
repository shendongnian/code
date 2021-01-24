		public string ReverseSentence(string input)
		{
			var word = new Queue<char>( new [] {' '} );
			var sentence = new Stack<Queue<char>>(new [] { word });
			
			foreach (char c in input)
			{
				if (c == ' ')
				{
					sentence.Push(word = new Queue<char>());
				}
				word.Enqueue(c);
			}
			return new string(sentence.SelectMany( w => w ).ToArray());
		}
