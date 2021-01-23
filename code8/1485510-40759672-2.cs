    public static readonly BindableProperty ColumnsProperty = BindableProperty.Create("Columns", typeof(List<Column>), typeof(TablePrac));
    public List<Column> Columns
    {
        set
        {
            SetValue(ColumnsProperty, value);
        }
        get
        {
            return (List<Column>)GetValue(ColumnsProperty);
        }
    }
