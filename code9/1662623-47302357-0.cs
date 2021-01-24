    public class TestViewModel : BindableBase, INotifyPropertyChanged
    {
        public void SetPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new     PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private string myTitle;
        public string MyTitle
        {
            get { return myTitle; }
            set { 
                  SetProperty(ref myTitle, value); 
                  SetPropertyChanged("MyTitle");
                }
        }
        public TestViewModel()
        {
            MyTitle = "Title from VM";
        }
    }
