    public class ColumnInfo
    {
        public string ColumnName { get; set; }
        public string DatabaseType { get; set; }
    }
    
    public static IEnumerable<ColumnInfo> GetColumnsInfo(Type linqTableClass)
        {
            Debug.WriteLine(string.Format("Table: {0}", linqTableClass.Name));
            /// In-Case this has to grow in the future.  Using a list for the arg names to search for.  
            /// The primary arg should be in position 0 of the array.
            List<string> argNames = new List<string>() { "DbType", "Name" };
            foreach (var fld in linqTableClass.GetProperties())
            {
                Debug.WriteLine(string.Format("Field Name: {0}", fld.Name));
                foreach (var attr in fld.GetCustomAttributesData().Cast<CustomAttributeData>()
                    .Where(r => r.AttributeType == typeof(ColumnAttribute))
                    .Where(a => a.NamedArguments
                        .Select(n => n.MemberName)
                        .Intersect(argNames)
                        .Any()))
                {
                    var args = attr.NamedArguments;
                    if (attr.NamedArguments.Select(r => r.MemberName).Intersect(argNames).Any())
                        yield return new ColumnInfo()
                        {
                            ColumnName = argNames[1],
                            DatabaseType = args
                                .Where(r => r.MemberName == argNames[0])
                                .Select(r => r.TypedValue.Value.ToString())
                                .SingleOrDefault()
                        };
                    else
                        yield return new ColumnInfo()
                        {
                            ColumnName = argNames[0],
                            DatabaseType = args
                                .Where(r => r.MemberName == argNames[0])
                                .Select(r => r.TypedValue.Value.ToString())
                                .SingleOrDefault()
                        };
                }
            }
        }
