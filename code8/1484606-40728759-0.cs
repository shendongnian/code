	public class Range<T>
	{
		internal T Lower { get; set; }
		internal T Upper { get; set; }
		
		private Range()
		{
		}
		
		internal Range(T lower, T upper)
		{
			Lower = lower;
			Upper = upper;
		}
		
		internal Range(string source)
		{
			string[] parts = source.Split(',');
			
			if(parts.Length <= 1)
				throw new ArgumentException();
			
			var tc = TypeDescriptor.GetConverter(typeof(T));
			if(!tc.CanConvertFrom(typeof(string)))
				throw new ArgumentException();
			
			
			this.Lower = ((T)tc.ConvertFrom(parts[0]));
			this.Upper = ((T)tc.ConvertFrom(parts[1]));
		}
		
		public static bool CanConvertFromString(string source)
		{
			string[] parts = source.Split(',');
			
			if(parts.Length <= 1)
				throw new ArgumentException();
			
			var tc = TypeDescriptor.GetConverter(typeof(T));
			
			return tc.CanConvertFrom(typeof(string));
		}
		
		public static Range<T> Parse(string source)
		{
			Range<T> ret = new Range<T>();
			
			string[] parts = source.Split(',');
			
			if(parts.Length <= 1)
				throw new ArgumentException();
			
			return new Range<T>(source);
		}
	
		public string LowerString { get { return Lower.ToString(); } }
		public string UpperString { get { return Upper.ToString(); } }
	
		public string AsString { get { return string.Format("{0},{1}", LowerString, UpperString); }}// gets the string-representation of the object
	}
