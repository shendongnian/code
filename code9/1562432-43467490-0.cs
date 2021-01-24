    public class ItemPresenter : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public string Value1 { get; set; } = "A";
        public string Value2 { get; set; } = "B";
        public IEnumerable GetErrors(string propertyName) => new[] { "ERROR" };
        public bool HasErrors => true;
        public void Reset()
        {
            Value1 = "A";
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value1)));
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(Value1)));
            Value2 = "B";
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value2)));
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(Value2)));
        }
    }
