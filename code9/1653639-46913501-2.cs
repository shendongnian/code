    <DataGridTemplateColumn Header="Audited" >
        <DataGridTemplateColumn.CellTemplate>
            <DataTemplate>
                <CheckBox Checked="DataGridCheckBoxColumn_Checked" Unchecked="DataGridCheckBoxColumn_Unchecked"
                                          IsChecked="{Binding IsAudited, UpdateSourceTrigger=PropertyChanged}"/>
            </DataTemplate>
        </DataGridTemplateColumn.CellTemplate>
        <DataGridTemplateColumn.CellEditingTemplate>
            <DataTemplate>
                <CheckBox Checked="DataGridCheckBoxColumn_Checked" Unchecked="DataGridCheckBoxColumn_Unchecked"
                                          IsChecked="{Binding IsAudited, UpdateSourceTrigger=PropertyChanged}"/>
            </DataTemplate>
        </DataGridTemplateColumn.CellEditingTemplate>
    </DataGridTemplateColumn>
----------
    private void DataGridCheckBoxColumn_Checked(object sender, RoutedEventArgs e)
    {
        CheckBox checkBox = sender as CheckBox;
        var model = checkBox.DataContext as YourClass;
        //update the DB using the properties of your model...
    }
