    public class JustCounts : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private int m_totalCount = 100;
        public int TotalCount
        {
            get { return m_totalCount; }
            set
            {
                if (value != m_totalCount)
                {
                    m_totalCount = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
