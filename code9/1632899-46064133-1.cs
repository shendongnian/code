    // MainWindow.xaml.cs 
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.dataGridView.ItemsSource = HelperClass.ReadCsv(@"PathToRead\configuration.csv");
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var temp = new List<ItemGrid>();
            for (int i = 0; i < this.dataGridView.Items.Count; i++)
            {
                if (this.dataGridView.Items[i] is ItemGrid) // DataGrid pads it's item collection with elements we didn't add.
                    temp.Add((ItemGrid)this.dataGridView.Items[i]);
            }
            HelperClass.WriteCsv(temp, @"PathToSave\new_configuration.csv");
        }
    }
