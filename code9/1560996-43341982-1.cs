    namespace WPFGridLoadingRow
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
            private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
            {
                dgGrid.ScrollIntoView(e.Row.Item);
            }
        }
    }
