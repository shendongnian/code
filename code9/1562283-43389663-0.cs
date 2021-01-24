    private void cmbId_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        UGrid.ItemsSource = new List<YourEntityType> { cmbId.SelectedItem as YourEntityType };
    }
----------
    <DataGrid x:Name="UGrid" AutoGenerateColumns="False">
        <DataGrid.Columns>
            <DataGridTextColumn Header="Auto Name" Binding="{Binding AutoName, UpdateSourceTrigger=PropertyChanged}" Width="100"/>
            <DataGridTextColumn Header="Color" Binding="{Binding Color, UpdateSourceTrigger=PropertyChanged}" Width="100"/>
        </DataGrid.Columns>
    </DataGrid>
