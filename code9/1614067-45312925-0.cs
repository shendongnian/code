    public delegate void DeleteRow(bool doDelete);
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int selectedRow = 0;
        public DeleteRow deleteRowDelegate;
        public void ReportDelete(bool delete)
        {
            // Delete the row here.
        }
        public MainWindow()
        {
            InitializeComponent();
            deleteRowDelegate += new DeleteRow(ReportDelete);
        }
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {            
            // Here, get the row number to selectedRow.
            SecondaryWin win = new SecondaryWin(deleteRowDelegate);
            win.ShowDialog();
            // At this point, if DELETE was clicked in your secondary window, code would have executed ReportDelete() method.
        }
    }
