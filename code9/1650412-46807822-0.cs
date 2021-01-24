    <telerikGrid:RadDataGrid ItemsSource="{x:Bind AvailableVM.PickListItems,Mode=OneWay}"
                     Background="White"
                     SelectionUnit="Cell"
                     GridLinesBrush="Pink"
                     AlternateRowBackground="Azure"
                     AutoGenerateColumns="False"
                     ScrollViewer.VerticalScrollBarVisibility="Hidden"
                    x:Name="radgrid">
        <telerikGrid:RadDataGrid.Columns>
            <telerikGrid:DataGridTextColumn PropertyName="Country"/>
            <telerikGrid:DataGridTextColumn PropertyName="City"/>
            <telerikGrid:DataGridTemplateColumn Header="Assign"  SizeMode="Auto">
                <telerikGrid:DataGridTemplateColumn.CellContentTemplate>
                    <DataTemplate x:DataType="local:DataTest">
                        <Button Background="Transparent"  Command="{x:Bind ListSelectedCommand }" Content="command testing" />
                    </DataTemplate>
                </telerikGrid:DataGridTemplateColumn.CellContentTemplate>
            </telerikGrid:DataGridTemplateColumn>
        </telerikGrid:RadDataGrid.Columns> 
    </telerikGrid:RadDataGrid>
