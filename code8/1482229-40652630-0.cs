    public partial class MainWindow
    {
        public MainWindow()
        {
            this.InitializeComponent();
    
            List<ItemViewModel> newList = new List<ItemViewModel>();
    
    
            newList.Add(new ItemViewModel() { Name = "foo", Status = Status.finished});
            newList.Add(new ItemViewModel() { Name = "foo1", Status = Status.waiting });
            newList.Add(new ItemViewModel() { Name = "foo2", Status = Status.executing });
    
    
            newList[1].Items.Add(new ItemViewModel() { Name = "subFoo", Status = Status.executing });
            newList[1].Items.Add(new ItemViewModel() { Name = "subFoo1", Status = Status.executing });
    
            DataContext = newList;
    
        
        }
    }
    
