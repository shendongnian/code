	class Program
	{
		static void Main()
		{
			if(TextTool.CountStringOccurrences(Filetest, "\\")>=2)
			{
				//You have more than one folder
			}
			else
			{
				//One file no folder
			}
		}
	}
	public static class TextTool
	{
		public static int CountStringOccurrences(string text, string pattern)
		{
			// Loop through all instances of the string 'text'.
			int count = 0;
			int i = 0;
			while ((i = text.IndexOf(pattern, i)) != -1)
			{
				i += pattern.Length;
				count++;
			}
			return count;
		}
	}
