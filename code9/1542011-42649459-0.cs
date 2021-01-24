    public class ViewModel : INotifyPropertyChanged
    {
        private readonly List<string> _internalList;
        public IEnumerable ListProperty => _internalList.AsEnumerable();
        // ...
    }
