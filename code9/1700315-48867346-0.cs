    <DataGrid x:Name="dg" ItemsSource="{Binding Addresses}" AutoGenerateColumns="False">
        <DataGrid.Columns>
            <DataGridTextColumn Header="Address" Binding="{Binding Address}" />
            <DataGridTextColumn Header="City" Binding="{Binding City}" />
            <DataGridTextColumn Header="State" Binding="{Binding State}" />
            ...
        </DataGrid.Columns>
    </DataGrid>
