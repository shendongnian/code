    <DataGrid ItemsSource="{Binding Posts}" AutoGenerateColumns="False" IsReadOnly="True">
        <DataGrid.Columns>
            <DataGridTextColumn Header="Id" Binding="{Binding Id}" />
            <DataGridTextColumn Header="Title" Binding="{Binding Title}" />
            <DataGridTextColumn Header="BlogUrl" Binding="{Binding Blog.Url}" />
        </DataGrid.Columns>
    </DataGrid>
    <ComboBox ItemsSource="{Binding Urls}" SelectedItem="{Binding Url}" />
