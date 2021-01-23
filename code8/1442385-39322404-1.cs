    public partial class MainWindow : Window
    {
        List<string> myList = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void subscribeToNetflixButton_Click(object sender, RoutedEventArgs e)
        {
            Netflix netflix = new Netflix("Stir Crazy");
            Observer subscriberOne = new Observer();
            netflix.AddObserver(subscriberOne);
            myList.Add("Netflix");
            listBox.Items.AddRange(myList.ToArray());//This line should be changed
        }
        private void subscribeToHuluButton_Click(object sender, RoutedEventArgs e)
        {
            Hulu hulu = new Hulu("Willy Wonka and the Chocolate Factory");
            Observer subscriberTwo = new Observer();
            hulu.AddObserver(subscriberTwo);
            myList.Add("Hulu");
            listBox.Items.AddRange(myList.ToArray());//And this line
        }
    }
