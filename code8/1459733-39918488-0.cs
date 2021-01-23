    public partial class MainWindow : Window
        {
            
            MyViewModel vm = new MyViewModel();
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = vm;
            }
    
            private void button1_Click(object sender, RoutedEventArgs e)
            {
                
    
                DXDialog d = new DXDialog("Information", DialogButtons.OkCancel,true);
                PropertyGrid p = new PropertyGrid() { DataContext = vm }; // Dialog view and Main view are both bound to the same viewmodel instance here.
                d.Content = p;
                d.SizeToContent = System.Windows.SizeToContent.WidthAndHeight;
                d.Owner = this;
                d.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
                var result = d.ShowDialog();
                if (result == true)
                {
                    
                    this.button1.Content = vm.Customer1;
                    
                }
                else
                {
                    // write the logic for "Cancel" button click. You can revert the Datacontext to the earlier value 
                    //of the ViewModel by having saved its cloned object in this same method
                }
    
    
            }
    
            
        }
