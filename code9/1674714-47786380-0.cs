	void Main()
	{
		foreach (var adult in new Adults())
		{
			Console.WriteLine(adult.ToString());
		}
	}
	
	public class Adult
	{
		public override string ToString() => "Adult!";
	}
	
	public class Adults
	{
		public class Enumerator
		{
			public Adult Current { get; private set; }
			public bool MoveNext()
			{
				if (this.Current == null)
				{
					this.Current = new Adult();
					return true;
				}
				this.Current = null;
				return false;
			}
			public void Reset() { this.Current = null; }
		}
		public Enumerator GetEnumerator() { return new Enumerator(); }
	}
