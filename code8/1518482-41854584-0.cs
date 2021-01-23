    <DataGridComboBoxColumn x:Name="col_LowerComparer2"
                                        SelectedItemBinding="{Binding DataContext.LowerComparer2, RelativeSource={RelativeSource AncestorType=DataGrid}, NotifyOnSourceUpdated=True, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
                                        DisplayMemberPath="ArithmeticSignValue"
                                        Header="LowComp">
        <DataGridComboBoxColumn.ElementStyle>
            <Style TargetType="ComboBox">
                <Setter Property="ItemsSource" Value="{Binding Path=DataContext.LowerComparers2, RelativeSource={RelativeSource AncestorType=DataGrid}}" />
            </Style>
        </DataGridComboBoxColumn.ElementStyle>
        <DataGridComboBoxColumn.EditingElementStyle>
            <Style TargetType="ComboBox">
                <Setter Property="ItemsSource" Value="{Binding Path=DataContext.LowerComparers2, RelativeSource={RelativeSource AncestorType=DataGrid}}" />
            </Style>
        </DataGridComboBoxColumn.EditingElementStyle>
    </DataGridComboBoxColumn>
