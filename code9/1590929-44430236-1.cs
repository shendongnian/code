    public static class ColumnsCache<T>
    {
        public static readonly IReadOnlyDictionary<MemberInfo, string> Columns = BuildColumnsDictionary();
        public static Dictionary<MemberInfo, string> BuildColumnsDictionary()
        {
            var dict = new Dictionary<MemberInfo, string>();
            var members = typeof(T).GetMembers(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.MemberType == MemberTypes.Field || x.MemberType == MemberTypes.Property);
            foreach (MemberInfo member in members)
            {
                var attr = member.GetCustomAttribute<ColumnNameAttribute>(true);
                if (attr != null)
                {
                    dict.Add(member, attr.Column);
                }
            }
            return dict;
        }
    }
