    <GridView x:Name="MyGridView" Loaded="MyGridView_Loaded">
        <GridView.ItemsPanel>
            <ItemsPanelTemplate>
                <StackPanel Orientation="Horizontal"/>
            </ItemsPanelTemplate>
        </GridView.ItemsPanel>
    
        <GridView.ItemContainerTransitions>
            <TransitionCollection>
                <EntranceThemeTransition FromHorizontalOffset="50" IsStaggeringEnabled="True" />
            </TransitionCollection>
        </GridView.ItemContainerTransitions>
    </GridView>
</
    public ObservableCollection<int> Items { get; set; } = new ObservableCollection<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    
    private void MyGridView_Loaded(object sender, RoutedEventArgs e)
    {
        foreach (var item in Items)
            MyGridView.Items.Add(item);
    }
