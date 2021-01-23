        public string ToCamelCase(string str,string sep)
        {
           str = str.Split(new[] {sep}, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => char.ToUpperInvariant(s[0]) + s.Substring(1, s.Length - 1))
                .Aggregate(string.Empty, (s1, s2) => s1 + s2);
            return str.First().ToString().ToLowerInvariant() + str.Substring(1);
        }
        
   
