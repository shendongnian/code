    <DataGrid
        ItemsSource="{Binding MasksSourceListBound.MaskDetails}"
        >
        <DataGrid.Columns>
            <DataGridTextColumn Binding="{Binding OtherTestProperty}" />
            <DataGridComboBoxColumn 
                Header="Test" 
                SelectedItemBinding="{Binding SelectedItem}"
                >
                <DataGridComboBoxColumn.ElementStyle>
                    <Style TargetType="ComboBox">
                        <Setter 
                            Property="ItemsSource" 
                            Value="{Binding DataContext.MasksSourceListBound.ListParts, RelativeSource={RelativeSource AncestorType=DataGrid}, PresentationTraceSources.TraceLevel=High}" 
                            />
                    </Style>
                </DataGridComboBoxColumn.ElementStyle>
                <DataGridComboBoxColumn.EditingElementStyle>
                    <Style TargetType="ComboBox">
                        <Setter Property="ItemsSource" Value="{Binding DataContext.MasksSourceListBound.ListParts, RelativeSource={RelativeSource AncestorType=DataGrid}}" />
                    </Style>
                </DataGridComboBoxColumn.EditingElementStyle>
            </DataGridComboBoxColumn>
        </DataGrid.Columns>
