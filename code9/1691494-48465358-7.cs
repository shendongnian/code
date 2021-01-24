    <DataGrid Name="dgOrderList" 
            AutoGenerateColumns="False" 
            ItemsSource="{Binding OrderList, Mode=TwoWay}" 
            IsReadOnly="True"
            SelectionMode="Single"
            SelectionUnit="FullRow">
        <DataGrid.Columns>
            <DataGridTextColumn Width="Auto" Header="ID" Binding="{Binding OrderId}"/>
            <DataGridTextColumn Width="*" Header="Description" Binding="{Binding OrderDescription}"/>
        </DataGrid.Columns>
    </DataGrid>
