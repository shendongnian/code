    private class KeysEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            if (x.Equals(y))
            {
                return true;
            }
            return (x.Equals("BBB") && y.Equals("DDD"))
                || (x.Equals("DDD") && y.Equals("BBB"));
        }
    
        public int GetHashCode(string str)
        {
            return str.GetHashCode();
        }
    }
    // your original code using the comparer:
    var query= ds.Tables[0].AsEnumerable()
                .GroupBy(g => g.Field<string>("category"), new KeysEqualityComparer())
                .Select(a => new workType
                {
                    Key = a.Key,
                    Item = a.ToList()
                });
