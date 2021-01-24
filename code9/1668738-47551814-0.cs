    public Window1()
    {
        InitializeComponent();
        dgrPoints.ItemContainerGenerator.ItemsChanged += ItemContainerGenerator_ItemsChanged;
        dgrPoints.LoadingRow += DgrPoints_LoadingRow;
        dgrPoints.ItemsSource = ...;
    }
    private void DgrPoints_LoadingRow(object sender, DataGridRowEventArgs e)
    {
        e.Row.Tag = (e.Row.GetIndex() + 1).ToString();
    }
    private void ItemContainerGenerator_ItemsChanged(object sender, ItemsChangedEventArgs e)
    {
        IEnumerable<DataGridRow> rows = FindVisualChildren<DataGridRow>(dgrPoints);
        foreach (DataGridRow row in rows)
            row.Tag = (row.GetIndex() + 1).ToString();
    }
    private static IEnumerable<T> FindVisualChildren<T>(DependencyObject dependencyObject) where T : DependencyObject
    {
        if (dependencyObject != null)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(dependencyObject); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(dependencyObject, i);
                if (child != null && child is T)
                {
                    yield return (T)child;
                }
                foreach (T childOfChild in FindVisualChildren<T>(child))
                {
                    yield return childOfChild;
                }
            }
        }
    }
----------
    <DataGrid Name="dgrPoints" AutoGenerateColumns="False" 
              ItemsSource="{Binding UpdateSourceTrigger=Default, Mode=OneWay}"
              CanUserSortColumns="False"
              IsReadOnly="True">
        <DataGrid.Columns>
            <DataGridTextColumn x:Name="colI" Binding="{Binding Path=Tag, Mode=OneWay, 
                RelativeSource={RelativeSource AncestorType=DataGridRow}}"/>
            <DataGridTextColumn x:Name="colX" Binding="{Binding X}" Header="X"/>
            <DataGridTextColumn x:Name="colY" Binding="{Binding Y}" Header="Y"/>
            <DataGridTextColumn x:Name="colZ" Binding="{Binding Z}" Header="Z"/>
        </DataGrid.Columns>
    </DataGrid>
