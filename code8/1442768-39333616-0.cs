    public class ViewModel : INotifyPropertyChanged
    {
        private bool show_element;
        public bool Show_element
        {
            get { return show_element; }
            set
            {
                show_element = value;
                this.OnPropertyChanged("Show_element");
                Debug.WriteLine("Show_element value changed");
            }
        }
        public ViewModel()
        {
        }
        public void ButtonClicked()
        {
            Show_element = !Show_element;
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public void OnPropertyChanged(string propertyName = null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
