    public struct NameDatePair : IEquatable<NameDatePair>
    {
    	public readonly string Name;
    	public readonly DateTime Date;
    	public NameDatePair(string name, DateTime date) { Name = name; Date = date; }
    	static IEqualityComparer<string> NameComparer {  get { return StringComparer.InvariantCultureIgnoreCase; } }
    	public override int GetHashCode() { return NameComparer.GetHashCode(Name) ^ Date.GetHashCode(); }
    	public override bool Equals(object obj) { return obj is NameDatePair && Equals((NameDatePair)obj); }
    	public bool Equals(NameDatePair other) { return NameComparer.Equals(Name, other.Name) && Date == other.Date; }
    }
