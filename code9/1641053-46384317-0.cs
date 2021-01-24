    void Main()
    {
        var dt = new DataTable();
        dt.Columns.Add("MergedName", typeof(string));
    
        dt.Rows.Add("Abby Kelley Foster");
        dt.Rows.Add("Kelley Foster");
        dt.Rows.Add("Abby Kelley");
    
        dt.AsEnumerable()
            .Select(r => r.Field<string>("MergedName"))
            .GroupBy(s => s, new SubstringComparer())
            .Select(g => new { g.Key, Count = g.Count() })
            .Dump();
    
    }
    
    public class SubstringComparer : IEqualityComparer<string>
    {
        public bool Equals(string left, string right)
        {
            return left.Contains(right) || right.Contains(left);
        }
    
        public int GetHashCode(string value)
        {
            return 0; // Just return 0; There is no hashing mechanism implemented that gives "Abby Kelley Foster" and "Abby Kelley" the same hashcode.
        }
    }
