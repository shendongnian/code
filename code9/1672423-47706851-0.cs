	public static int GetMaxLineCount(Text text)
	{
		var textGenerator = new TextGenerator();
		var generationSettings = text.GetGenerationSettings(text.rectTransform.rect.size);
		var lineCount = 0;
		var s = new StringBuilder();
		while (true)
		{
			s.Append("\n");
			textGenerator.Populate(s.ToString(), generationSettings);
			var nextLineCount = textGenerator.lineCount;
			if (lineCount == nextLineCount) break;
			lineCount = nextLineCount;
		}
		return lineCount;
	}
