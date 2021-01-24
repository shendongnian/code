     <Grid>
            <DataGrid ColumnWidth="*" AutoGenerateColumns="False" x:Name="dgLOA">
                <DataGrid.Columns>
                    <DataGridTemplateColumn Header="Pay Advice">
                        <DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <local:MyControl/>
                            </DataTemplate>
                        </DataGridTemplateColumn.CellTemplate>
                    </DataGridTemplateColumn>
                </DataGrid.Columns>
            </DataGrid>
        </Grid>
