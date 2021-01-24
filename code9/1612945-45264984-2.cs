	public class ImmutableEnumerator<T> : IImmutableEnumerator<T>
	{
		public static (bool Succesful, IImmutableEnumerator<T> NewEnumerator) Create(IEnumerable<T> source)
		{
			var enumerator = source.GetEnumerator();
			var successful = enumerator.MoveNext();
			return (successful, new ImmutableEnumerator<T>(successful, enumerator));
		}
		private IEnumerator<T> _enumerator;
		private (bool Succesful, IImmutableEnumerator<T> NewEnumerator) _runOnce = (false, null);
		private ImmutableEnumerator(bool successful, IEnumerator<T> enumerator)
		{
			_enumerator = enumerator;
			this.Current = successful ? _enumerator.Current : default(T);
		}
		public (bool Succesful, IImmutableEnumerator<T> NewEnumerator) MoveNext()
		{
			if (_runOnce.NewEnumerator == null)
			{
				var successful = _enumerator.MoveNext();
				_runOnce = (successful, new ImmutableEnumerator<T>(successful, _enumerator));
			}
			return _runOnce;
		}
		public T Current { get; private set; }
	}
