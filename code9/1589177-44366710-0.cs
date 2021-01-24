    <DataGrid x:Name="dg">
        <DataGrid.Resources>
            <DataTemplate x:Key="dtA">...</DataTemplate>
            <DataTemplate x:Key="dtB">...</DataTemplate>
            <local:Selector x:Key="selector" TemplateA="{StaticResource dtA}" TemplateB="{StaticResource dtA}" />
        </DataGrid.Resources>
        <DataGrid.Columns>
            <DataGridTextColumn Binding="{Binding A}" />
            <DataGridTextColumn Binding="{Binding B}" />
            <DataGridTemplateColumn CellEditingTemplateSelector="{StaticResource selector}">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <TextBlock Text="{Binding C}" />
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
        </DataGrid.Columns>
    </DataGrid>
----------
    public class Selector : DataTemplateSelector
    {
        public DataTemplate TemplateA { get; set; }
        public DataTemplate TemplateB { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            System.Data.DataRowView dr = item as DataRowView;
            //return TemplateA or TemplateB based on your logic
            return base.SelectTemplate(item, container);
        }
    }
