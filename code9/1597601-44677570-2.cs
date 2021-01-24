    <!-- resources -->
    <CollectionViewSource x:Key="devicesCollection" IsLiveSortingRequested="True" IsLiveGroupingRequested="True" Source="{Binding MyCollection}">
        <!-- Sorting -->
        <CollectionViewSource.SortDescriptions>
            <componentModel:SortDescription PropertyName="Id" />
        </CollectionViewSource.SortDescriptions>
        <!-- Grouping -->
        <CollectionViewSource.GroupDescriptions>
            <PropertyGroupDescription PropertyName="City"/>
        </CollectionViewSource.GroupDescriptions>
    </CollectionViewSource>
    <DataTemplate x:Key="GroupingHeader">
        <Border Background="Gray">
            <TextBlock Margin="10 5 5 5" FontSize="12" FontWeight="Bold" Text="{Binding Name}"/>
        </Border>
    </DataTemplate>
    <!-- data grid -->
    <DataGrid ItemsSource="{Binding Source={StaticResource ResourceKey=devicesCollection}, Mode=OneWay}">
        <DataGrid.GroupStyle>
            <GroupStyle HeaderTemplate="{StaticResource ResourceKey=GroupingHeader}" />
        </DataGrid.GroupStyle>
    </DataGrid>
