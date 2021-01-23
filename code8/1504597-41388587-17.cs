    public class MainPageViewModel
    {
        //...
        Command<SelectedItemChangedEventArgs> _listViewItemSelectedCommand;
        //...
        public event EventHandler<Page> NavigationRequested;
        //...
        public Command<SelectedItemChangedEventArgs> ListViewItemSelectedCommand => _listViewItemSelectedCommand ??
        (_listViewItemSelectedCommand = new Command<SelectedItemChangedEventArgs>(ExecuteListViewItemSelectedCommand));
        //...
        void ExecuteListViewItemSelectedCommand(SelectedItemChangedEventArgs e)
        {
            var item = e as TableMainMenuItems;
            
            switch (item?.display_text)
            {
                case "Forms List":
                    OnNavigationRequested(new FormsListPage());
                    break;
    
                case "New Pre-Job":
                    OnNavigationRequested(new PreJobPage(0));
                    break;
            }
        }
        
        void OnNavigationRequested(Page pageToNavigate) => NavigationRequested?.Invoke(this, pageToNavigate);
        //...
    }
