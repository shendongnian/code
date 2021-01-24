    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<SomeObject> list = new List<SomeObject>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new SomeObject
                {
                    Id = $"{i}{i}",
                    Nombre = $"Nombre {i}"
                });
            }
            DataContext = list;
        }
        private void DataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (sender is DataGrid)
            {
                DataGrid dataGrid = sender as DataGrid;
                SomeObject selectedObject = dataGrid.SelectedItem as SomeObject;
                if (selectedObject != null)
                {
                    string selectedId = selectedObject.Id;
                }
            }
        }
    }
    internal class SomeObject
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        //...
    }
