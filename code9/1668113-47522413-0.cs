	public class UserEntry
	{
		private readonly string _originalValue;
		
		public UserEntry(string input)
		{
			_originalValue = input;
		}
		
		public bool IsInt
		{
			get
			{
				return int.TryParse(_originalValue, out var dummy);
			}			
		}
		
		public int ToInt()
		{
			return ToInt(default(int));
		}
		
		public int ToInt(int defaultValue)
		{
			int result;
			
			bool ok = int.TryParse(_originalValue, out result);
			return ok ? result : defaultValue;
		}
		
		static public implicit operator UserEntry(string input)
		{
			return new UserEntry(input);
		}
		
		static public implicit operator Int32(UserEntry input)
		{
			return input.ToInt();
		}
	}
