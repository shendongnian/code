    public partial class MainPage : ContentPage
    {
        private ObservableCollection<String> animals;
        private int _counter = 0;
        public MainPage()
        {
            InitializeComponent();
            animals = new ObservableCollection<string>(new List<string>{"dog","cat","fish","elephant","monkey"});
            ListView.ItemsSource = animals;
        }
        private void Button_OnClicked(object sender, EventArgs e)
        {
            var newElement = "new animal"+_counter;
            _counter++;
            animals.Add(newElement);
            ListView.ScrollTo(newElement, ScrollToPosition.End, true);
        }
    }
