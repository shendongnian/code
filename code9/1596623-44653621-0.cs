    public class SelectedIndexData
    {
        public int SelectedIndex { get; set; }
    }
    public partial class MainWindow : Window
    {
        private readonly SelectedIndexData _selectedIndexData = new SelectedIndexData();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedIndexData.SelectedIndex = ComboBox.SelectedIndex;
        }
        private void ShowChildWindow(object sender, RoutedEventArgs e)
        {
           new ChildWindow(_selectedIndexData).Show();
        }
    }
    public partial class ChildWindow : Window
    {
        private SelectedIndexData _selectedIndexData;
        public ChildWindow(SelectedIndexData selectedIndexData)
        {
            InitializeComponent();
            _selectedIndexData = selectedIndexData; // do whatever you want with your data here
        }
    }
