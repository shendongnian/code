    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string property = "") => 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        readonly List<string> _list = new List<string> { "a", "b", "c", "d", "e" };
        public IEnumerable<string> List1 => _list.Where(o => o != Selected2);
        public IEnumerable<string> List2 => _list.Where(o => o != Selected1);
        string _selected1;
        public string Selected1
        {
            get { return _selected1; }
            set
            {
                _selected1 = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(List2));
            }
        }
        string _selected2;
        public string Selected2
        {
            get { return _selected2; }
            set
            {
                _selected2 = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(List1));
            }
        }
    }
