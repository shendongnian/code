    public class Model
    {
        public string Name { get; set; }
    }
    public class ViewModel : INotifyPropertyChanged
    {
        private readonly Model model;
        public ViewModel(Model model)
        {
            this.model = model;
        }
        public bool Loading { get; set; }
        public bool IsDirtyName { get; private set; }
        private string name;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (this.Loading)
                {
                    this.name = value;
                    return;
                }
 
                if (this.model.Name != value)
                {
                    IsDirtyName = true;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            // ...
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
