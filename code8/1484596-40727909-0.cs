	public abstract class Range<T> 
	{
		internal T Lower { get; set; }
		internal T Upper { get; set; }
		
		internal Range(T lower, T upper)
		{
			Lower = lower;
			Upper = upper;
		}
		
		// this method I would use inside TypeConverter...
		internal Range(string source)
		{
			string[] parts = source.Split(',');
			
			if(parts.Length <= 1)
				throw new ArgumentException();
			
			this.Upper = this.StringToValue(parts[0]);
			this.Lower = this.StringToValue(parts[1]);
		}
	
		public string LowerString { get { return ValueToString(Lower); } }
		public string UpperString { get { return ValueToString(Upper); } }
	
		public abstract string ValueToString(T value); // must be overridden
		public abstract T StringToValue(string source); // must be overridden
	
		public string AsString { get { return string.Format("{0},{1}", LowerString, UpperString); }}// gets the string-representation of the object
	}
