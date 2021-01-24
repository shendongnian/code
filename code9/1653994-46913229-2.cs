    static void Main(string[] args)
	{
		string sentence = "Here you enter your sentence...";
		string[] words = sentence.Split(' ');
		OutputDelayedText(words);
	}
	private static void OutputDelayedText(string[] myText)
	{
		foreach (var word in myText)
		{
			Console.Write(word + " ");
			Thread.Sleep(200);
		}
	}
