    public partial class MainWindow : Window
        {
            List<shopItems> availableItems;
            public List<shopItems> AvailableItems
            {
                get
                {
                    return availableItems;
                }
                set
                {
                    availableItems = value;
                }
            }
    
            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
                availableItems = new List<shopItems> { new shopItems { Name = "Item 1" }, new shopItems { Name = "Item 2" } };
            }
    
            public class shopItems
            {
                private string name;
                public string Name
                {
                    get
                    {
                        return name;
                    }
                    set
                    {
                        name = value;
                    }
                }
    
                private bool isItemSelected = false;
                public bool IsItemSelected
                {
                    get
                    {
                        return isItemSelected;
                    }
                    set
                    {
                        isItemSelected = value;
                    }
                }
            }
        }
