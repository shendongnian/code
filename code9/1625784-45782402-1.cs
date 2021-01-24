    public partial class MainWindow : Window
    {
        private string[] mylist = new string[3];
        public MainWindow()
        {
            InitializeComponent();
            mylist[0] = @"D:\media1";
            mylist[1] = @"D:\media1";
            mylist[2] = @"D:\media1";
            mediaelement.Source = new Uri(mylist[0]);
            mediaelement.Play();
        }
        private void mediaelement_MediaEnded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < mylist.Length - 1; i++)
            {
                Uri current = new Uri(mylist[i]);
                if (mediaelement.Source == current)
                {
                    mediaelement.Source = new Uri(mylist[i + 1]);
                    break;
                }
            }
            mediaelement.Play();
        }
    }
