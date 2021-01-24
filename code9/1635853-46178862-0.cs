    <DataGridComboBoxColumn Header="Unit" Width="*">
        <DataGridComboBoxColumn.ElementStyle>
            <Style TargetType="ComboBox">
                <Setter Property="ItemsSource" Value="{Binding Units}" />
            </Style>
        </DataGridComboBoxColumn.ElementStyle>
        <DataGridComboBoxColumn.EditingElementStyle>
            <Style TargetType="ComboBox">
                <Setter Property="ItemsSource" Value="{Binding Units}" />
            </Style>
        </DataGridComboBoxColumn.EditingElementStyle>
    </DataGridComboBoxColumn>
