    public sealed partial class AirportListView : Page
    {
        public ObservableCollection<string> MyAirports { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<AirportItem> Airports { get; set; }
    
        public AirportListView()
        {
            this.InitializeComponent();
            Airports = new ObservableCollection<AirportItem>
            {
                new AirportItem {Name = "EDDB"},
                new AirportItem {Name = "LGIR"},
                new AirportItem {Name = "LFPO"},
                new AirportItem {Name = "EGKK"}
            };
        }
    
        private void AirportListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is AirportItem clickedAirport)
            {
                if (MyAirports.Contains(clickedAirport.Name))
                {
                    MyAirports.Remove(clickedAirport.Name);
                    clickedAirport.IsMyAirport = false;
                }
                else
                {
                    MyAirports.Add(clickedAirport.Name);
                    clickedAirport.IsMyAirport = true;
                }
            }
        }
    }
    
    public class AirportItem : BindableBase
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty<string>(ref _name, value); }
        }
    
        private bool _isMyAirport = false;
        public bool IsMyAirport
        {
            get { return _isMyAirport; }
            set { SetProperty<bool>(ref _isMyAirport, value); }
        }
    }
