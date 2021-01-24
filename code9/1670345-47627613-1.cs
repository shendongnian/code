    public class FileM
    {
    }
    public partial class MainWindow : Window
    {
        public ObservableCollection<FileM> ListFiles = new ObservableCollection<FileM>();
        public MainWindow()
        {
            InitializeComponent();
            DynamicList.ItemsSource = ListFiles;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(ListFiles.Count<7){ListFiles.Add(new FileM());}
        }
    }
