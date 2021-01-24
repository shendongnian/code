    <telerikGrid:RadDataGrid Name="MyRadDataGrid" ItemsSource="{Binding}" AutoGenerateColumns="False" UserEditMode="Inline">
        <telerikGrid:RadDataGrid.Columns >
            <telerikGrid:DataGridTemplateColumn Header="Product">
                <telerikGrid:DataGridTemplateColumn.CellContentTemplate>
                    <DataTemplate>
                        <TextBlock Text="{Binding Product}" ManipulationMode="TranslateX"  ManipulationCompleted="TextBlock_ManipulationCompleted"  ManipulationDelta="TextBlock_ManipulationDelta"/>
                    </DataTemplate>
                </telerikGrid:DataGridTemplateColumn.CellContentTemplate>
            </telerikGrid:DataGridTemplateColumn>
        </telerikGrid:RadDataGrid.Columns>
    </telerikGrid:RadDataGrid>
