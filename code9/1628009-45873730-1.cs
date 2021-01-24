    public class VM : INotifyPropertyChanged
    {
      public event PropertyChangedEventHandler PropertyChanged;
      private string _selectedText;
      public string SelectedText
      {
        get { return _selectedText; }
        set
        {
          _selectedText = value;
          RaisePropertyChanged("SelectedText");
        }
      }
      private void RaisePropertyChanged(string propertyName)
      {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
    }
