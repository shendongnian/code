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
			// read
			var text = File.ReadAllLines(path);
			// print
			foreach (var line in text)
				Console.WriteLine(line);
			// replace
			text[text.Length - 1] = text.Last().Replace(",", ".");
			// overwrite
			File.WriteAllLines(path, text);
			// read
			string[] lines2 = File.ReadAllLines(path);
			// print
			foreach (var line in lines2)
				Console.WriteLine(line);
		}
	}
