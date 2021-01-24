		public class Parser 
		{
			const string _r1 = "...";
			private string _text;
			public Parser(string text)
			{
				_text = text;
			}
			public IEnumerable<string> Find()
			{
				return Regex.Matches(_text, _r1)
					.Cast<Match>()
					.Select(match => match.Value)
					.Distinct();
			} 
		}
