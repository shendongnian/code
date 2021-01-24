	private static void OutputDelayedText(string[] myText)
	{
		foreach (var word in myText)
		{
			Console.Write(word + " ");
			Thread.Sleep(200);
		}
	}
