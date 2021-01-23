    public static readonly BindableProperty ColumnsProperty = BindableProperty.Create("Columns", typeof(IEnumerable<Column>), typeof(TablePrac), new List<Column>());
    
    public IEnumerable<Column> Columns
    {
        set
        {
            SetValue(ColumnsProperty, value);
        }
        get
        {
            return (IList<Column>)GetValue(ColumnsProperty);
        }
    }
