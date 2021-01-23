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
    public PurchaseOrderEntry()
    {
        InitializeComponent();
        this.DataContext = new MainViewModel(povm,tcvm);
        ...
