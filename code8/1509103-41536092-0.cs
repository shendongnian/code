    <DataGridComboBoxColumn Header="State" SelectedItemBinding="{Binding States}">
      <DataGrid.Columns>
        <DataGridComboBoxColumn.ElementStyle>
            <Style TargetType="ComboBox">
                <Setter Property="ItemsSource" Value="{Binding States}"/>
                <Setter Property="IsReadOnly" Value="True"/>
            </Style>
        </DataGridComboBoxColumn.ElementStyle>
    </DataGridComboBoxColumn>
