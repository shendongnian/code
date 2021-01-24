    <Grid>
        <DataGrid Name="studentGrid" CanUserAddRows="False" Grid.Row="3" Grid.ColumnSpan="2" AutoGenerateColumns="False" ItemsSource="{Binding Students, Mode=TwoWay}" >
            <DataGrid.Columns>                
                <DataGridTextColumn Header="Student's grade" Binding="{Binding StudentGrade}">
                </DataGridTextColumn>
                <DataGridTextColumn Header="Student's Name" Binding="{Binding StudentName}">
                </DataGridTextColumn>
            </DataGrid.Columns>
        </DataGrid>
    </Grid>
