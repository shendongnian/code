	// Custom comparer taking generic input parameter and a delegate function to do matching
	public class CustomComparer<T> : IEqualityComparer<T> {
		private readonly Func<T, object> _match;
		
		public CustomComparer(Func<T, object> match) {
			_match = match;
		}
		
		// tries to match both argument its return values against eachother
		public bool Equals(T data1, T data2) {
			return object.Equals(_match(data1), _match(data2));
		}
		
		// overly simplistic implementation
		public int GetHashCode(T data) {
			var matchValue = _match(data);
			if (matchValue == null) {
				return 42.GetHashCode();
			}
			return matchValue.GetHashCode();
		}
	}
