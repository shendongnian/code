    public class SourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            StaticTablesGroup stg = value as StaticTablesGroup;
            List<object> merged = new List<object>();
            if(stg.GroupTables != null)
                merged.AddRange(stg.GroupTables);
            if(stg.StaticTablesGroups != null)
                merged.AddRange(stg.StaticTablesGroups);
            return merged;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
----------
    <TreeView x:Name="tv" ItemsSource="{Binding TablesVM.TreeData}">
        <TreeView.Resources>
            <data:SourceConverter x:Key="conv" />
            <HierarchicalDataTemplate ItemsSource="{Binding Path=., Converter={StaticResource conv}}" 
                                      DataType="{x:Type data:StaticTablesGroup}">
                <Label Content="{Binding Name}"/>
            </HierarchicalDataTemplate>
            <DataTemplate DataType="{x:Type data:GroupTable}">
                <Label Content="{Binding Name}"/>
            </DataTemplate>
        </TreeView.Resources>
    </TreeView>
