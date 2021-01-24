    <Grid>
    <Grid.ColumnDefinitions>
        <ColumnDefinition />
        <ColumnDefinition />
    </Grid.ColumnDefinitions>
    <TreeView ItemsSource="{Binding MyItemSource}">
        <!-- Get the selected item here (watch how to in the linked answer) -->
    </TreeView>
    <ContentPresenter Grid.Column="1" 
                      Content="{Binding Path=SelectedItem}"
                      >
        <ContentPresenter.ContentTemplate>
            <DataTemplate>
                <DataGrid>
                    <!-- Your DatGrids or what ever -->
                </DataGrid>
            </DataTemplate>
        </ContentPresenter.ContentTemplate>
    </ContentPresenter>
    </Grid>
