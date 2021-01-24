    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
    public sealed class ColumnNameAttribute : Attribute
    {
        public readonly string Column;
        public ColumnNameAttribute(string columnName)
        {
            this.Column = columnName;
        }
    }
