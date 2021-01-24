      public class ActionTabViewModal
      {
        // These Are the tabs that will be bound to the TabControl 
        public ObservableCollection<ActionTabItem> Tabs { get; set; }
        public ActionTabViewModal()
        {
            Tabs = new ObservableCollection<ActionTabItem>();
        }
        public void Populate()
        {
            // Add A tab to TabControl With a specific header and Content(UserControl)
            Tabs.Add(new ActionTabItem { Header = "UserControl 1", Content = new TestUserControl() });
            // Add A tab to TabControl With a specific header and Content(UserControl)
            Tabs.Add(new ActionTabItem { Header = "UserControl 2", Content = new TestUserControl() });
        }
    }
