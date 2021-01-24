    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    
        public List<string> Items { get; set; } = new List<string>();
    
        private string selectItem = "Nico";
        public string SelectItem { get { return selectItem; } set { selectItem = value; OnPropertyChanged(); } }
    
        public MainPageViewModel()
        {
            Items.Add("Nico");
            Items.Add("Song");
            Items.Add("Xiao");
        }
