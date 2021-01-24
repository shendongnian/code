    public class View: UserControl
    {
       public View()
       {
           this.InitializeComponent();
           Loaded += (o, e) => ViewModel.SomeCommandExecuted += ViewModel_SomeCommandExecuted;
       }
    
       ViewModelBase ViewModel => (ViewModelBase)DataContext;
    
    
      private bool ViewModel_SomeCommandExecuted(object data)  
      { 
         //load the data into view
      }
    }
