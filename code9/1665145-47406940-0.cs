    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            list = new ObservableCollection<Data>{
                 new Data { Country = "India", Capital = "New Delhi"},
                 new Data { Country = "South Africa", Capital = "Cape Town"},
                 new Data { Country = "Nigeria", Capital = "Abuja" },
                 new Data { Country = "Singapore", Capital = "Singapore" },
                 new Data { Country = "India", Capital = "New Delhi"}
            };
            list.CollectionChanged += List_CollectionChanged;
            DataGrid.ItemsSource = list;
        }
        private void List_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                DataGrid.ScrollIndexIntoView(list.Count - 1);
            }
        }
        public ObservableCollection<Data> list { get; set; }
    }
    public class Data
    {
        public string Country { get; set; }
        public string Capital { get; set; }
    }
