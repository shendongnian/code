    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="200"/>
            <ColumnDefinition Width="*" />
        </Grid.ColumnDefinitions>
        <DataGrid Grid.Column="0" ItemsSource="{Binding OpenExcelColl}" AutoGenerateColumns="False" AlternationCount="{Binding OpenExcelColl.Count}" 
                  VirtualizingPanel.IsVirtualizing="False" CanUserAddRows="False" SelectedItem="{Binding SelectedExcelObject}">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Name" Binding="{Binding Name}" IsReadOnly="True"/>
                <DataGridTextColumn Header="Path" Binding="{Binding CompletePath}" IsReadOnly="True"/>
                <DataGridTextColumn Header="Type" Binding="{Binding ExtType}" IsReadOnly="True"/>
            </DataGrid.Columns>
            ...
        </DataGrid>
        <StackPanel Grid.Column="1">
            <!--  Additional controls here -->
        </StackPanel>
    </Grid>
