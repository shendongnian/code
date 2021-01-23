	public class TComplex
	{
		public AType AType { get; set; }
		public BType BType { get; set; }
		public IList<CType> CTypes { get; set; }
		public IEnumerable<ParsedValue> GetParsedValues()
		{
			foreach (var parsedValue in AType.GetParsedValues())
				yield return parsedValue;
			foreach (var parsedValue in BType.GetParsedValues())
				yield return parsedValue;
				
			foreach (var cType in CTypes)
				foreach (var parsedValue in cType.GetParsedValues())
					yield return parsedValue;
		}
	}
	public class AType
	{
		public int AInteger { get; set; }
		public int BInteger { get; set; }
		public string AString { get; set; }
		public ParsedValue ParsedValue { get; set; }
		public IEnumerable<ParsedValue> GetParsedValues()
		{
			yield return ParsedValue;
		}
	}
	public class BType
	{
		public string AString { get; set; } 
		public IList<DType> DTypes { get; set; }
		public ParsedValue ParsedValue { get; set; }
		public IEnumerable<ParsedValue> GetParsedValues()
		{
			yield return ParsedValue;
		}
	}
	public class CType
	{
		public int Id { get; set; }
		public string Value { get; set; }
		public ParsedValue ParsedValue { get; set; }
		public IEnumerable<ParsedValue> GetParsedValues()
		{
			yield return ParsedValue;
		}
	}
