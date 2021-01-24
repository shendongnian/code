	public class Quiz
	{
		public Quiz() { Ranges = new List<SelectionRange>(); }
		public string Text { get; set; }
		public List<SelectionRange> Ranges { get; private set; }
		public string Render()
		{
			/* rendering logic*/
		}
	}
