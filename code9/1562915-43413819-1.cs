    public partial class ListView : UserControl
        {
            public ListView()
            {
                InitializeComponent();
                ListViewModel lvm = new ListViewModel();
                this.DataContext = lvm; //this is what you are missing                
            }
        }
