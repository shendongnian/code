    class MainViewModel:INotifyPropertyChanged
    {
       private ObservableCollection<TreeItem> _arbol = 
           new ObservableCollection<TreeItem>( 
               new List<TreeItem>
               { 
                   new TreeItem("Remedys") 
               } );
       public ObservableCollection<TreeItem> Arbol
       {
          set 
          { 
             _arbol = value; 
             OnPropertyChanged("Arbol"); 
          }
             get { return _arbol; }
       }
    
       public MainViewModel()
       {
           //Populate Arbol
           ...
        }
    }
