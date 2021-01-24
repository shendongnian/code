    [ImplementPropertyChanged]
    public class MyViewModel
    {
        public ViewableCollection<MySecondViewModel> Collection1 { get; set; }
        public MyViewModel()
        {
            this.Collection1 = new ViewableCollection<MySecondViewModel>();
        }
    }
    
    [ImplementPropertyChanged]
    public class MySecondViewModel
    { 
        public string MyColumn1 { get; set; }
        public string MyColumn2 { get; set; }
        public ViewableCollection<MyThirdViewModel> Collection2 { get; set; }
        public MySecondViewModel()
        {
            this.Collection1 = new ViewableCollection<MyThirdViewModel>();
        }
    }
 
    [ImplementPropertyChanged]
    public class MyThirdViewModel
    { 
        public string MyColumn1 { get; set; }
        public string MyColumn2 { get; set; }
    }
     
    //...
    this.DataContext = new MyViewModel();
