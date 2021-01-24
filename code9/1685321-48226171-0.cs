	public class Program
	{
		public static void Main()
		{
			var input = "I'm Learning c#";
			var sentence = new Stack<Queue<char>>();
			var word = new Queue<char>( new [] {' '} );
			
			foreach (char c in input)
			{
				if (c == ' ')
				{
					sentence.Push(word);
					word = new Queue<char>();
				}
				word.Enqueue(c);
			}
			sentence.Push(word);
			
			var output = new string(sentence.SelectMany( w => w ).ToArray());
			Console.WriteLine(output);
		}
	}
