        public class ComboBoxPopulation : INotifyPropertyChanged
    {
        public string Number { get; set; }
        private bool selected = false;
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propName));
            }
        }
        public bool Selected
        {
            get { return selezionato; }
            set
            {
                if (selezionato != value)
                {
                    selezionato = value;
                    
                    OnPropertyChanged("Selected");
                }
            }
        }
    }
