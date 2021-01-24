    public class MyClass
    {
        public List<string> Columns { get; set; }
        public List<MyRow> Rows { get; set; }
    }
    public class MyRow : DynamicObject
    {
        public MyClass OwnerClass { get; set; }
        public List<object> Values { get; set; }
        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return OwnerClass.Columns;
        }
        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            if (indexes.Length == 1 && OwnerClass != null)
            {
                if (indexes[0] is string stringIndex && OwnerClass.Columns.Contains(stringIndex))
                {
                    result = Values[OwnerClass.Columns.IndexOf(stringIndex)];
                    return true;
                }
                else if (indexes[0] is int intIndex)
                {
                    result = Values[intIndex];
                    return true;
                }
            }
            result = null;
            return false;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if ((!string.IsNullOrEmpty(binder.Name) && OwnerClass.Columns.Contains(binder.Name)))
            {
                result = Values[OwnerClass.Columns.IndexOf(binder.Name)];
                return true;
            }
            result = null;
            return false;
        }
        public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value)
        {
            if (indexes.Length == 1 && OwnerClass != null)
            {
                if (indexes[0] is string stringIndex && OwnerClass.Columns.Contains(stringIndex))
                {
                    Values[OwnerClass.Columns.IndexOf(stringIndex)] = value;
                    return true;
                }
                else if (indexes[0] is int intIndex)
                {
                    Values[intIndex] = value;
                    return true;
                }
            }
            return false;
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if ((!string.IsNullOrEmpty(binder.Name) && OwnerClass.Columns.Contains(binder.Name)))
            {
                Values[OwnerClass.Columns.IndexOf(binder.Name)] = value;
                return true;
            }
            return false;
        }
    }
