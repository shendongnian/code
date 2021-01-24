    public static class URLExtensions
    {
        public static string ToKeyValueURL(this object obj)
        {
            var keyvalues = obj.GetType().GetProperties()
                .ToList()
                .Select(p => $"{p.Name} = {p.GetValue(obj)}")
                .ToArray();
                
            return string.Join('&',keyvalues);
        }
    }
