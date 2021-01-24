    public partial class MyControl : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public byte Value
        {
           get { return GetByteData(); }
           set
           {
               SetByteData(value);
               PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
           }
        }
        ...
    }
