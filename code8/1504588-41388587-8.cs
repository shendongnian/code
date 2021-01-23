    public class MainPageViewModel
    {
        ...
        Command<ItemSelectedEventArgs> _listViewItemSelectedCommand
        ...
        public event EventHandler< NavigationEventArgs> NavigationRequested;
        ...
        public Command<ItemSelectedEventArgs> ListViewItemSelectedCommand => _listViewItemSelectedCommand ??
        (_listViewItemSelectedCommand = new Command<ItemSelectedEventArgs>(ExecuteListViewItemSelectedCommand));
        ...
        void ListViewItemSelectedCommand(ItemSelectedEventArgs e)
        {
            var item = e as TableMainMenuItems;
            
            switch (item.display_text)
            {
                case "Forms List":
                    OnNavigationRequested(new FormsListPage());
                    break;
    
                case "New Pre-Job":
                    OnNavigationRequested(new PreJobPage(0));
                    break;
            }
        }
        
        void OnNavigationRequested(Page pageToNavigate)
        {
            NavigationRequested?.Invoke(null, new NavigationEventArgs(pageToNavigate);
        }
        ...
    }
