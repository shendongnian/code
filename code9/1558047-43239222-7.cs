    class CascadingPropertyVM : ObservableObject
    {
        public CascadingPropertyVM()
        {
            new PropertyChangeCascade<CascadingPropertyVM>(this)
                .AddCascade(s => s.Name,
                t => new { t.DoubleName, t.TripleName });
        }
        private string _name;
        public string Name
        {
            get => _name;
            set => SetValue(ref _name, value);
        }
        public string DoubleName => $"{Name} {Name}";
        public string TripleName => $"{Name} {Name} {Name}";
    }
