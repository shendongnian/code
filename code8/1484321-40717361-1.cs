     public partial class MainWindow : Window
     {
        public MainViewModel MainViewModel { get; set; }
        public MainWindow()
        {
            MainViewModel = new MainViewModel(new TypeViewmodel(), new ItemCategoryViewModel());
            this.DataContext = MainViewModel;
            InitializeComponent();
        }
    }
    public class MainViewModel
    {
        public TypeViewmodel TypeViewmodel { get; set; }
        public ItemCategoryViewModel ItemCategoryViewmodel { get; set; }
        public MainViewModel(TypeViewmodel povm, ItemCategoryViewModel tcvm)
        {
            this.TypeViewmodel = povm;
            this.ItemCategoryViewmodel = tcvm;
        }
    }
    public class ItemCategoryViewModel
    {
        public ItemCategoryViewModel()
        {
            TextBoxMessageItemCategoryViewModel = "Test - ItemCategoryViewModel";
        }
        public String TextBoxMessageItemCategoryViewModel { get; set; }
    }
    public class TypeViewmodel
    {
        public TypeViewmodel()
        {
            TextBoxMessageTypeViewmodel = "Test - TypeViewmodel";
        }
        public String TextBoxMessageTypeViewmodel { get; set; }
    }
