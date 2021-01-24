    public class Field : ObservableObject
    {
        private string _name;
        private string _value;
        private bool _flag;
        public string Name { get => _name; set => Set(ref _name, value); }
        public string Value { get => _value; set => Set(ref _value, value); }
        public bool Flag { get => _flag; set => Set(ref _flag, value); }
    }
