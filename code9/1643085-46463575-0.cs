    public class YourObject : IComparable{
    public YourObject(string name) {
        Name = name;
    }
    public string Name { get; set; }
    public override string ToString()
    {
        return GetHashCode().ToString() + "_" + Name;
    }
    #region IComparable Members
    public int CompareTo(Object other)
    {
        return Comparer.Default.Compare(this.ToString(), other.ToString());
    }
    #endregion
}
