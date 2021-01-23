    <DataGrid x:Name="EmployeesDataGrid" HorizontalAlignment="Left" Margin="545,31,0,0" VerticalAlignment="Top" Height="554" Width="290"
                      DataContext="{StaticResource CollectionViewSource}" 
                      AutoGenerateColumns="False" EnableRowVirtualization="True" ItemsSource="{Binding}" RowDetailsVisibilityMode="VisibleWhenSelected" IsReadOnly="True"
                      PreviewKeyDown="dg_PreviewKeyDown">
        <DataGrid.Columns>
            <DataGridTextColumn x:Name="IdColumn" Header="Id" Binding="{Binding Id}"/>
            <DataGridTextColumn x:Name="FirstNameColumn" Header="First Name" Binding="{Binding FirstName}"/>
            <DataGridTextColumn x:Name="LastNameColumn" Header="Last Name" Binding="{Binding LastName}"/>
            <DataGridTextColumn x:Name="MobilePhoneNumberColumn" Header="Mobile Phone" Binding="{Binding MobilePhoneNumber}"/>
        </DataGrid.Columns>
    </DataGrid>
----------
    private void dg_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        Employee employee = EmployeesDataGrid.SelectedItem as Employee;
        if (employee != null)
        {
            using (var databaseContext = new CompanyManagerContext())
            {
                try
                {
		            databaseContext.Employees.Attach(employee);
                    databaseContext.Employees.Remove(employee);
                    databaseContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
