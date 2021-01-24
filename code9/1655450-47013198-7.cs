    <DataGrid                 
            AutoGenerateColumns="False"
            CanUserAddRows="False"
            CanUserReorderColumns="True"
            CanUserResizeColumns="True"
            ItemsSource="{Binding Clients.RowItems}">
        <DataGrid.Columns>
            <DataGridTextColumn Header="Given Name" Binding="{Binding GivenName, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"></DataGridTextColumn>
            <DataGridTextColumn Header="Family Name" Binding="{Binding FamilyName, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"></DataGridTextColumn>
            <DataGridTextColumn Header="Gender" Binding="{Binding Gender, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"></DataGridTextColumn>
            <DataGridTextColumn Header="Date of Birth" Binding="{Binding DateOfBirth, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"></DataGridTextColumn>
        </DataGrid.Columns>
    </DataGrid>
