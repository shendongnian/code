    var result = db1.Database.SqlQuery<BookViewModel>("AuthorProcedure1 @name", bookTitle).ToList();
    Info.ItemsSource = result;
----------
    <DataGrid x:Name="Info" AutoGenerateColumns="False" Background="Honeydew" Canvas.Top="200" Canvas.Left="30" 
                      Width="259" Height="50" >
        <DataGrid.Columns>
            <DataGridTextColumn Header="Title" Binding="{Binding Title}" />
            <DataGridTextColumn Header="Name" Binding="{Binding Name}" />
            <DataGridTextColumn Header="Surname" Binding="{Binding Surname}" />
        </DataGrid.Columns>
    </DataGrid>
