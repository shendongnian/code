    public class ParamViewModel : INotifyPropertyChanged
    {
        public string Prompt { get; set; }
        public ObservableCollection<string> Details { get; set;}
        public string SelectedValue { get; set; }
    }
