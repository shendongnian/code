    <GridViewColumn Width="200" DisplayMemberBinding="{Binding EmpNo}">
        <GridViewColumn.CellTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding}"
                           TextAlignment="Right" />
                </DataTemplate>
        </GridViewColumn.CellTemplate>
        <GridViewColumn.Header>
        <GridViewColumnHeader Content=" Name"
                              HorizontalContentAlignment="Left" />
        </GridViewColumn.Header>
    </GridViewColumn>
