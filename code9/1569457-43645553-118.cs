    public partial class ListViewDatabaseStyle : UserControl, IControlView
        {
            public ListViewDatabaseStyle ()
            {
                InitializeComponent();
            }
    
            public INotifyPropertyChanged ViewModel
            {
                get
                {
                    return (INotifyPropertyChanged)DataContext;
                }
                set
                {
                    DataContext = value;
                }
            }
        }
    
