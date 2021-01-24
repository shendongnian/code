    <Grid>
            <DataGrid ItemsSource="{Binding CourtCases,RelativeSource={RelativeSource FindAncestor, AncestorType=Window}}"  Name="CourtCasesGrid" ColumnWidth="*"
                      SelectionUnit="FullRow">
                <DataGrid.Resources>
                    <Style TargetType="DataGridRow">
                        <EventSetter Event="MouseDoubleClick" Handler="CourtCasesGridRowDoubleClick"/>
                    </Style>
                </DataGrid.Resources>
            </DataGrid>
        </Grid>
