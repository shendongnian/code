    <DataGrid x:Name="INVItemsDataGrid" ItemsSource="{Binding}">
        <DataGrid.Columns>
            <DataGridComboBoxColumn x:Name="INVSCDropDown" DisplayMemberPath="CodeName" SelectedValuePath="CodeName" SelectedValueBinding="{Binding CodeName}">
                <DataGridComboBoxColumn.ElementStyle>
                    <Style TargetType="{x:Type ComboBox}">
                        <Setter Property="ItemsSource" Value="{Binding Path=., RelativeSource={RelativeSource AncestorType=DataGrid}}" />
                    </Style>
                </DataGridComboBoxColumn.ElementStyle>
                <DataGridComboBoxColumn.EditingElementStyle>
                    <Style TargetType="{x:Type ComboBox}">
                        <Setter Property="ItemsSource" Value="{Binding Path=., RelativeSource={RelativeSource AncestorType=DataGrid}}" />
                    </Style>
                </DataGridComboBoxColumn.EditingElementStyle>
            </DataGridComboBoxColumn>
        </DataGrid.Columns>
    </DataGrid>
