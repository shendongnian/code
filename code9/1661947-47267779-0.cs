    public static readonly DependencyProperty HiddenColsProperty =
        DependencyProperty.RegisterAttached("HiddenColsInternal", typeof(LabelCollection), typeof(MyDataGridHelper), new PropertyMetadata
        {
            DefaultValue = new LabelCollection(),
            PropertyChangedCallback = (obj, e) =>
            {
                var grid = (DataGrid)obj;
                if (grid != null)
                {
                    var arr = ((LabelCollection)e.NewValue).Cast<Label>().ToArray();
                    hidden[grid.Name] = (arr ?? new Label[0]).Select(l => l.Name).ToArray();
                }
            }
