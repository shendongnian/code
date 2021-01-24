      public static string ToQueryString(this object query)
    {
        var result = new List<string>();
        var properties = query.GetType().GetProperties().Where(p => p.GetValue(query, null) != null && p.GetValue(query, null).ToString() != "0");
        foreach (var p in properties)
        {
            var value = p.GetValue(query, null);
            var collection = value as ICollection;
            if (collection != null)
            {
                result.Add(p.Name+"="+string.Join(",", collection.Select(o => HttpUtility.UrlEncode(o.ToString())).ToArray());
            }
            else
            {
                result.Add($"{p.Name}={HttpUtility.UrlEncode(value.ToString())}");
            }
        }
        return string.Join("&", result.ToArray());
    }
