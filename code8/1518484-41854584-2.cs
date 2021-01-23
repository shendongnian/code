    <DataGridComboBoxColumn x:Name="col_LowerComparer2"
                                        SelectedItemBinding="{Binding LowerComparer2, NotifyOnSourceUpdated=True, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
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
