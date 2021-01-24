    public static readonly DependencyProperty HiddenColsProperty =
        DependencyProperty.RegisterAttached("HiddenColsInternal", typeof(ObservableCollection<Label>), typeof(MyDataGridHelper), new PropertyMetadata
        {
            DefaultValue = GetObservableCollectionDefaultValueFactory(),
            PropertyChangedCallback = (obj, e) =>
            {
                var grid = (DataGrid)obj;
                if (grid != null)
                {
                    var arr = ((LabelCollection)e.NewValue).Cast<Label>().ToArray();
                    hidden[grid.Name] = (arr ?? new Label[0]).Select(l => l.Name).ToArray();
                }
            }
    private static object GetObservableCollectionDefaultValueFactory()
    {
        Type type = Type.GetType("MS.Internal.ObservableCollectionDefaultValueFactory`1, WindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");
        Type closedType = type.MakeGenericType(typeof(Label));
        ConstructorInfo constructorInfo = closedType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, Type.EmptyTypes, null);
        return constructorInfo.Invoke(null);
    }
