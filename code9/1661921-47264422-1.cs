    using System.Linq;
    
    namespace WpfApp1
    {
        public partial class MainWindow
        {
            public MainWindow()
            {
                InitializeComponent();
    
                DataGrid1.ItemsSource = Enumerable.Range(1, 10).ToList();
            }
        }
    }
