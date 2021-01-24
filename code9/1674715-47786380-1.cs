	public class Adults
	{
		private class Enumerator : IEnumerator<Adult>
		{
			public Adult Current { get; private set; }
	
			object IEnumerator.Current => this.Current;
	
			public void Dispose() { }
	
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
	
			public void Reset()
			{
				this.Current = null;
			}
		}
		public IEnumerator<Adult> GetEnumerator()
		{
			return new Enumerator();
		}
	}
