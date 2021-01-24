    <DataGrid ItemsSource="{Binding Assignments}" AutoGenerateColumns="False">
        <DataGrid.Columns>
            <DataGridTextColumn Header="Name" Binding="{Binding Name}"/>
            <DataGridTextColumn Header="Motor0" Binding="{Binding Motors[0].Name}" />
            <DataGridTextColumn Header="Motor1" Binding="{Binding Motors[1].Name}" />
            <DataGridTextColumn Header="Motor2" Binding="{Binding Motors[2].Name}" />
            <DataGridTextColumn Header="Motor3" Binding="{Binding Motors[3].Name}" />
        </DataGrid.Columns>
    </DataGrid>
