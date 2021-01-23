    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public MainPage()
        {
            this.InitializeComponent();
            Loaded += MainPage_Loaded;
        }
        //Collection to which the flipview is binded to.
        //An observable collection tells the view to keep monitoring the source
        private ObservableCollection<FlipViewDataClass> myDataCollection;
        public ObservableCollection<FlipViewDataClass> MyDataCollection
        {
            get { return myDataCollection; }
            set { myDataCollection = value; RaisePropertyChanged("MyDataCollection"); }
        }
        //sets up the data for the dummy test case scenario
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            List<FlipViewDataClass> myDummyData = new List<FlipViewDataClass>();
            myDummyData.Add(new FlipViewDataClass()
            {
                Description = "this is a simple image of a watch",
                IsDataVisible = false,
                ImagePath = new BitmapImage(new Uri(@"ms-appx:///Assets/11.png", UriKind.RelativeOrAbsolute))
            });
            MyDataCollection = ToObservableCollection<FlipViewDataClass>(myDummyData);
        }
        //Helps to convert a list to an Observable Collection.
        //It can be made into an extention method too but for simplicity I've made a simple method
        public static ObservableCollection<T> ToObservableCollection<T>(IEnumerable<T> coll)
        {
            var c = new ObservableCollection<T>();
            foreach (var e in coll)
                c.Add(e);
            return c;
        }
        
        //provides the show details functionality
        private void DetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            var currentItem = narrowFlipview.SelectedItem as FlipViewDataClass;
            currentItem.IsDescriptionVisible = true;
        }
        //provides the hide description functionality
        private void HideBtn_Click(object sender, RoutedEventArgs e)
        {
            var currentItem = narrowFlipview.SelectedItem as FlipViewDataClass;
            currentItem.IsDescriptionVisible = false;
        }
        //provides the Tapped to show the details pannel
        private void photo_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var currentItem = narrowFlipview.SelectedItem as FlipViewDataClass;
            currentItem.IsDataVisible = !currentItem.IsDataVisible;
        }
        //The RaiseProperty event to notify the view that the binding property has changed
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            //check if the property is null if not only then raise
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
