    public partial class MenuMasterPage : MasterDetailPage  
        {
            public List<MainMenuItem> MainMenuItems { get; set; }
            public MenuMasterPage()
            {
                // Set the binding context to this code behind.
                BindingContext = this;
    
                // Build the Menu
                MainMenuItems = new List<MainMenuItem>()
            {
                    new MainMenuItem() { Title = "Add Daily Expense", Icon = "menu_inbox.png", TargetType = typeof(Page1) },
                    new MainMenuItem() { Title = "My Expenses", Icon = "menu_stock.png", TargetType = typeof(Page2) }
            };
    
                // Set the default page, this is the "home" page.
                Detail = new NavigationPage(new Page1());
    
                InitializeComponent();
            }
            // When a MenuItem is selected.
            public void MainMenuItem_Selected(object sender, SelectedItemChangedEventArgs e)
            {
                var item = e.SelectedItem as MainMenuItem;
                if (item != null)
                {
                    if (item.Title.Equals("Add Daily"))
                    {
                        Detail = new NavigationPage(new AddDailyExpensePage());
                    }
                    else if (item.Title.Equals("My Expenses"))
                    {
                        Detail = new NavigationPage(new MyExpensesPage());
                    }
    
                    MenuListView.SelectedItem = null;
                    IsPresented = false;
                }
            }
        }
     public class MainMenuItem
        {
            public string Title { get; set; }
            public Type TargetType { get; set; }
            public string Icon { get; set; }
        }
