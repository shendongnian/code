    <DataGrid x:Name="datagrid" AutoGenerateColumns="False" CellEditEnding="datagrid_CellEditEnding">
            <DataGrid.Columns>
                
                <DataGridTextColumn Header="Val1" Binding="{Binding  Path=val1, UpdateSourceTrigger=PropertyChanged}"/>
                <DataGridTextColumn Header="Val2" Binding="{Binding  Path=val2, UpdateSourceTrigger=PropertyChanged}"/>
                <DataGridTextColumn Header="Val3" Binding="{Binding  Path=val3, UpdateSourceTrigger=PropertyChanged}"/>
                <DataGridTextColumn Header="total" FontWeight="Black" Binding="{Binding  Path=total}"  />
            </DataGrid.Columns>
        </DataGrid>
