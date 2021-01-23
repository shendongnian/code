    public class ButtonDescription
    {
        public object ButtonContent { get; set; }
        public ICommand ButtonCommand { get; set; }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }
        public ObservableCollection<ButtonDescription> ButtonListA { get; set; }
        public ObservableCollection<ButtonDescription> ButtonListB { get; set; }
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ButtonListA = new ObservableCollection<ButtonDescription>();
            ButtonListB = new ObservableCollection<ButtonDescription>();
            grid1.DataContext = this;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (TargetDescriptor.IsChecked == true)
            {
                ButtonListA.Add(new ButtonDescription { ButtonContent = button.Content, ButtonCommand = ApplicationCommands.Open });
            }
            else
            {
                ButtonListB.Add(new ButtonDescription { ButtonContent = button.Content, ButtonCommand = ApplicationCommands.Close });
            }
        }
        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Open");
        }
        private void Close_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Close");
        }
    }
