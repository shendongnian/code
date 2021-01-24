	public class ImmutableEnumerator<T> : IImmutableEnumerator<T>, IDisposable
	{
		public static (bool Succesful, IImmutableEnumerator<T> NewEnumerator) Create(IEnumerable<T> source)
		{
			var enumerator = source.GetEnumerator();
			var successful = enumerator.MoveNext();
			return (successful, new ImmutableEnumerator<T>(successful, enumerator));
		}
		private IEnumerator<T> _enumerator;
		private Lazy<(bool, IImmutableEnumerator<T>)> _runOnce;
		private ImmutableEnumerator(bool successful, IEnumerator<T> enumerator)
		{
			_enumerator = enumerator;
			this.Current = successful ? _enumerator.Current : default(T);
			if (!successful)
			{
				_enumerator.Dispose();
			}
			_runOnce = new Lazy<(bool, IImmutableEnumerator<T>)>(() =>
			{
				var s = _enumerator.MoveNext();
				return (s, new ImmutableEnumerator<T>(s, _enumerator));
			});
		}
		public (bool Succesful, IImmutableEnumerator<T> NewEnumerator) MoveNext()
		{
			return _runOnce.Value;
		}
		public T Current { get; private set; }
		public void Dispose()
		{
			_enumerator.Dispose();
		}
	}
