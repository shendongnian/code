    <GridView ItemsSource="{x:Bind Items}">
        <GridView.ItemContainerTransitions>
            <TransitionCollection>
                <EntranceThemeTransition FromHorizontalOffset="50" IsStaggeringEnabled="True"/>
            </TransitionCollection>
        </GridView.ItemContainerTransitions>
        <!--<GridView.ItemsPanel>
            <ItemsPanelTemplate>
                <StackPanel />
            </ItemsPanelTemplate>
        </GridView.ItemsPanel>-->
    </GridView>
</
    
    public ObservableCollection<int> Items { get; set; } = new ObservableCollection<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
