    public class HelperInfo : INotifyPropertyChanged
    {
        private DateTime m_CleanLogsDeletionDate;
        public DateTime CleanLogsDeletionDate
        {
            get
            {
                return m_CleanLogsDeletionDate;
            }
            set
            {
                if (m_CleanLogsDeletionDate != value)
                {
                    m_CleanLogsDeletionDate = value;
                    OnPropertyChanged();
                }
            }
        }
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
