    <Window.Resources>
        <CollectionViewSource x:Key="cvsTasks" Source="{Binding List}">
            <CollectionViewSource.GroupDescriptions>
                <PropertyGroupDescription PropertyName="Name" />
            </CollectionViewSource.GroupDescriptions>
        </CollectionViewSource>
    </Window.Resources>
    <Grid >
        <DataGrid AutoGenerateColumns="False" ItemsSource="{Binding Source={StaticResource cvsTasks}}">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Name" Binding="{Binding Name}"/>
                <DataGridTextColumn Header="EmpID" Binding="{Binding Employee.ID}"/>
                <DataGridTextColumn Header="EmpDeportment" Binding="{Binding Employee.Department}"/>
            </DataGrid.Columns>
        </DataGrid>
    </Grid>
