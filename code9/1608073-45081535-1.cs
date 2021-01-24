    <DataGridComboBoxColumn Header="Manufacturer" SelectedValueBinding="{Binding ManufacturerID, Mode=TwoWay}" 
                            SelectedValuePath="ID" 
                            DisplayMemberPath="CompanyName">
        <DataGridComboBoxColumn.ElementStyle>
            <Style TargetType="ComboBox">
                <Setter Property="ItemsSource" Value="{Binding DataContext.ManufacturerList, RelativeSource={RelativeSource AncestorType=UserControl}}" />
            </Style>
        </DataGridComboBoxColumn.ElementStyle>
        <DataGridComboBoxColumn.EditingElementStyle>
            <Style TargetType="ComboBox">
                <Setter Property="ItemsSource" Value="{Binding DataContext.ManufacturerList, RelativeSource={RelativeSource AncestorType=UserControl}}" />
            </Style>
        </DataGridComboBoxColumn.EditingElementStyle>
    </DataGridComboBoxColumn>
