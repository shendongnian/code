    public class DataObject : INotifyPropertyChanged
    {
        private double _progress;
        public double Progress
        {
            get { return _progress; }
            set { _progress = value; NotifyPropertyChanged("Progress"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
----------
    <DataTemplate>
        <ProgressBar Width="145" Height="15" Maximum="100" Value="{Binding Progress}" Tag="{Binding _name}"/>
    </DataTemplate>
