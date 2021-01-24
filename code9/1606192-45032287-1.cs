    <DataGridComboBoxColumn Header="ParamValue" SelectedItemBinding="{Binding ParamValue}">
        <DataGridComboBoxColumn.ElementStyle>
            <Style TargetType="ComboBox">
                <Setter Property="ItemsSource" Value="{Binding ParamValues}" />
            </Style>
        </DataGridComboBoxColumn.ElementStyle>
        <DataGridComboBoxColumn.EditingElementStyle>
            <Style TargetType="ComboBox">
                <Setter Property="ItemsSource" Value="{Binding ParamValues}" />
            </Style>
        </DataGridComboBoxColumn.EditingElementStyle>
    </DataGridComboBoxColumn>
