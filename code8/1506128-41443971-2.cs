	using System;
	using System.IO;
	using System.Linq;
	public class Program
	{
		public static void Main(string[] args)
		{
			// init
			var path = "output.ctl";
			var content =
				"Hello and Welcome" + Environment.NewLine
				+ "Hello and Welcome" + Environment.NewLine
				+ ",";
			File.WriteAllText(path, content);
			var text = File.ReadAllLines(path); // read the file as string[]
			
			foreach (var line in text) // print the file
				Console.WriteLine(line);
			text[text.Length - 1] = text.Last().Replace(",", "."); // replace
			
			File.WriteAllLines(path, text); // overwrite or write to a new file
			string[] lines2 = File.ReadAllLines(path); // read again
			foreach (var line in lines2) // then print to show the difference
				Console.WriteLine(line);
		}
	}
