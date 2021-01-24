    public class TestObj : System.ComponentModel.INotifyPropertyChanged
    {
        private string name;
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Name"));
            }
        }
        public TestObj(string name)
        {
            this.name = name;
        }
    }
