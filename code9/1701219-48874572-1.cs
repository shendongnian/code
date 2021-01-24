    public static IEnumerable<T> ToEnumerable<T>(this DataTable dt) where T : new() {
        var props = typeof(T).GetMembers(BindingFlags.Public|BindingFlags.Instance)
                             .Where(p => dt.Columns.Contains(p.Name) && (p.MemberType == MemberTypes.Field || p.MemberType == MemberTypes.Property)).ToList();
        foreach (var row in dt.AsEnumerable()) {
            var aT = new T();
            foreach (var p in props)
                p.SetValue(aT, row[p.Name]);
            yield return aT;
        }
    }
