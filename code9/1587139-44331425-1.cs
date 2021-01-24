    public class ALDViewModel: TabViewModel    
    public ObservableCollection<TabViewModel> TabItems { get; set; }
    TabViewModel aldTab = new ALDViewModel();
    aldTab.TabName = "ALD";
    TabItems.Add(aldTab);
    
