    public partial class View2 : ContentPage
    {
        View2ViewModel vm = null;
        public View2()
        {
            InitializeComponent();
        }
        public override async void OnAppearing() {
            
            if (vm == null) {
              vm = new View2ViewModel();
              await vm.FetchData();
              BindingContext = vm;
            }
        }
    }
    public class View2ViewModel
    {
        public ObservableCollection<DataModel> OpenData { get; set; } = new ObservableCollection<DataModel>();
        public async Task FetchData()
        {
            using (HttpClient hc = new HttpClient())
            {
              var jsonString = await hc.GetStringAsync("https://api.tfl.gov.uk/Line/Mode/tube%2Cdlr%2C%20overground/Status?detail=true");
                    OpenData = DataModel.FromJson(jsonString);
                }
            }
        }
    }
