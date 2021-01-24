    class Program
	{
		static void Main(string[] args)
		{
			MadLibs.Legend.Start();
			MadLibs.Another.Start();
            // to keep the console open
			Console.ReadKey(true);
		}
	}
	public static class MadLibs
	{
		public static MadLibSentence Legend = new MadLibSentence(
			new List<string>()
			{
				"noun", "adjective", "adjective", "adjective",
				"occupation", "occupation", "occupation",
				"adjective", "noun", "noun"
			},
			"They all agreed that it was a huge {0}, {1}, {2}, and {3}."
				+ " I have cross-examined these men, one of them a hard-headed "
				+ "{4}, one a {5}, and one a moorland {6}"
				+ ", who all tell the same story of this "
				+ "{7} {8}, exactly corresponding to the {9} of the legend.");
		public static MadLibSentence Another = new MadLibSentence(
			new List<string>()
			{
				"noun", "adjective", "adjective"
			},
			"This is a {0} mad lib. I don't think it is {1} {2}.");
	}
	public class MadLibSentence
	{
		private List<string> _parts { get; set; }
		private string _sentence { get; set; }
		public MadLibSentence(List<string> parts, string sentence)
		{
			this._parts = parts;
			this._sentence = sentence;
		}
		private List<string> GetInput()
		{
			var input = new List<string>();
			foreach (var part in _parts)
			{
				Console.WriteLine("Please enter a {0}: ", part);
				input.Add(Console.ReadLine());
			}
			return input;
		}
		public void Start()
		{
			Console.WriteLine(_sentence, GetInput().ToArray());
		}
	}
