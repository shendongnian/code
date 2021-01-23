    <StackPanel>
        <DataGrid ItemsSource="{Binding People}" AutoGenerateColumns="False">
          <DataGrid.Columns>
            <DataGridTextColumn Header="PersonId" Binding="{Binding PersonId}" />
            <DataGridTextColumn Header="First Name" Binding="{Binding FirstName}" />
            <DataGridTextColumn Header="Last Name" Binding="{Binding LastName}" />
          </DataGrid.Columns>
        </DataGrid>
        <TextBox Text="{Binding Text}" />
        <Button Command="{Binding CommandGetFirstName}" Height="30" Content="Get By First Name Above" />
    </StackPanel>
