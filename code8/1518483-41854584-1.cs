    <DataGridComboBoxColumn x:Name="col_LowerComparer2"
                                        SelectedItemBinding="{Binding LowerComparer2, NotifyOnSourceUpdated=True, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
                                        DisplayMemberPath="ArithmeticSignValue"
                                        Header="LowComp">
        <DataGridComboBoxColumn.ElementStyle>
            <Style TargetType="ComboBox">
                <Setter Property="ItemsSource" Value="{Binding LowerComparers2}" />
            </Style>
        </DataGridComboBoxColumn.ElementStyle>
        <DataGridComboBoxColumn.EditingElementStyle>
            <Style TargetType="ComboBox">
                <Setter Property="ItemsSource" Value="{Binding LowerComparers2}" />
            </Style>
        </DataGridComboBoxColumn.EditingElementStyle>
    </DataGridComboBoxColumn>
