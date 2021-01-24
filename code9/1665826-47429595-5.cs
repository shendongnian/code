	public class LoopController : IEnumerable<int>
	{
		public int Start;
		public int End;
		public int Increment;
	
		private IEnumerable<int> Enumerate()
		{
			var i = this.Start;
			while (i <= this.End)
			{
				yield return i;
				i += this.Increment;
			}
		}
	
		public IEnumerator<int> GetEnumerator()
		{
			return this.Enumerate().GetEnumerator();
		}
	
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
