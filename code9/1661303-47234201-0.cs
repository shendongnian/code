    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public DataGridRow SelectedRow { get; set; }
            public ObservableCollection<CourtCase> CourtCases { get; set; }
            public MainWindow()
            {
                InitializeComponent();
    
                CourtCases = new ObservableCollection<CourtCase>();
                CourtCases.Add(new CourtCase("1"));
                CourtCases.Add(new CourtCase("2"));
                CourtCases.Add(new CourtCase("3"));
                CourtCases.Add(new CourtCase("4"));
    
                SelectedRow = new DataGridRow();
    
                CourtCasesGrid.DataContext = CourtCases;
            }
    
            private void CourtCasesGridRowDoubleClick(object sender, MouseButtonEventArgs e)
            {
                DataGridRow row = sender as DataGridRow;
            }
        }
