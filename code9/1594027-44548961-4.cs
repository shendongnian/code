    <DataGrid ItemsSource="{Binding MySource}">
        <DataGrid.Columns>
            <DataGridTextColumn Header="VisitorName" Binding="{Binding VisitorName}"/>
            <DataGridTextColumn Header="Country" Binding="{Binding CountryNameString, Mode=OneWay}"/>
        </DataGrid.Columns>
    </DataGrid>
