	public class ImmutableEnumerator<T> : IImmutableEnumerator<T>
	{
		public static (bool Succesful, IImmutableEnumerator<T> NewEnumerator) Create(IEnumerable<T> source)
		{
			var e = source.GetEnumerator();
			return (e.MoveNext(), new ImmutableEnumerator<T>(e));
		}
		private IEnumerator<T> _enumerator;
		private ImmutableEnumerator(IEnumerator<T> enumerator)
		{
			_enumerator = enumerator;
			this.Current = _enumerator.Current;
		}
		public (bool Succesful, IImmutableEnumerator<T> NewEnumerator) MoveNext()
		{
			return (_enumerator.MoveNext(), new ImmutableEnumerator<T>(_enumerator));
	
		}
		public T Current { get; private set; }
	}
