     public interface IMainScreenTabItem : IScreen
        {
        }
    
        public class MainViewTestTabsViewModel : Conductor<IMainScreenTabItem>.Collection.OneActive
        {
            public MainViewTestTabsViewModel(IEnumerable<IMainScreenTabItem> tabs)
            {
    
                Items.Add(new ViewTabModel() {DisplayName = "Test"});
                Items.Add(new ViewTabModel() { DisplayName = "Test2" });
                Items.Add(new ViewTabModel() { DisplayName = "Test3" });
                Items.AddRange(tabs);
            }
        }
    
        public class ViewTabModel : Screen, IMainScreenTabItem
        {
            public ViewTabModel()
            {
    
            }
        }
