      public class MyListItem : INotifyPropertyChanged
      {
    
        double m_progressValue = 0.0;
        public double ProgressValue
        {
          get { return m_progressValue; }
          set
          {
            m_progressValue = value;
            OnPropertyChanged("ProgressValue");
          }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
      }
