    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly List<string> _internalList;
        public IEnumerable ListProperty => _internalList.AsEnumerable();
        // Other code here, including code to raise the "PropertyChanged" event when you want WPF to refresh any bindings to the ListProperty
    }
