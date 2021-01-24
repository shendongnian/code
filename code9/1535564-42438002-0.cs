    <DataGridComboBoxColumn Header="ViewTemplate" Width="150" SelectedItemBinding="{Binding ViewTemplate}">
        <DataGridComboBoxColumn.ElementStyle>
            <Style TargetType="ComboBox">
                <Setter Property="ItemsSource" Value="{Binding DataContext.ViewTemplates, RelativeSource={RelativeSource AncestorType=DataGrid}}"/>
                <Setter Property="IsReadOnly" Value="True"/>
            </Style>
        </DataGridComboBoxColumn.ElementStyle>
        <DataGridComboBoxColumn.EditingElementStyle>
            <Style TargetType="ComboBox">
                <Setter Property="ItemsSource" Value="{Binding DataContext.ViewTemplates, RelativeSource={RelativeSource AncestorType=DataGrid}}"/>
            </Style>
        </DataGridComboBoxColumn.EditingElementStyle>
    </DataGridComboBoxColumn>
                    
