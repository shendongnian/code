    public class CombinedViewModel
    {
        public wbItemViewModel WebItemVM= new wbItemViewModel();
        public InnerFlangeViewModel InnerFlangVM= new InnerFlangeViewModel();
        public OuterFlangeViewModel OuterVM= new OuterFlangeViewModel();       
    }
    
     public MainWindow()
     {           
        InitializeComponent();
        DataContext = new CombinedViewModel();
     }
