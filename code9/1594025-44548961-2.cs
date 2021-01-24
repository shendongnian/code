    <DataGrid ItemsSource="{Binding MySource}">
        <DataGrid.Columns>
            <DataGridTextColumn Header="VisitorName" Binding="{Binding VisitorName}"/>
            <DataGridTextColumn Header="Country" Binding="{Binding CountryId, Converter={StaticResource MyCustomConverter}, Mode=OneWay}"/>
        </DataGrid.Columns>
    </DataGrid>
