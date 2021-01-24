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
            string dbTypeArgName = "DbType";
            string fldPrimayName = "Storage";
            string fldSecondaryName = "Name";
            List<string> fldArgnames = new List<string>() { fldPrimayName, fldSecondaryName };
            foreach (var fld in linqTableClass.GetProperties())
            {
                Debug.WriteLine(string.Format("Field Name: {0}", fld.Name));
                foreach (var attr in fld.GetCustomAttributesData().Cast<CustomAttributeData>()
                    .Where(r => r.AttributeType == typeof(ColumnAttribute))
                    .Where(a => a.NamedArguments
                        .Select(n => n.MemberName)
                        .Intersect(fldArgnames)
                        .Any()))
                {
                    var fldName = attr.NamedArguments.Where(r => r.MemberName == fldSecondaryName).Count() != 0
                            ? attr.NamedArguments.Where(r => r.MemberName == fldSecondaryName).SingleOrDefault().TypedValue.Value.ToString()
                            : attr.NamedArguments.Where(r => r.MemberName == fldPrimayName).SingleOrDefault().TypedValue.Value.ToString();
                    var fldType = attr.NamedArguments
                            .Where(r => r.MemberName == dbTypeArgName)
                            .Select(r => r.TypedValue.Value.ToString())
                            .SingleOrDefault();
                    Debug.WriteLine(string.Format("\tTable Field Name {0} Table Type {1}", fldName, fldType));
                    yield return new ColumnInfo()
                    {
                        ColumnName = fldName,
                        DatabaseType = fldType,
                    };
                }
            }
        }
