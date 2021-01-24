    public class PublishedDateModel : INotifyPropertyChanged
        {
            private DateTime _publishDate;
    
            public DateTime PublishDate
            {
                get { return _publishDate; }
                set
                {
                    if (value.Equals(_publishDate)) return;
                    _publishDate = value;
                    OnPropertyChanged();
                }
            }
    
            public PublishedDateModel(DateTime date)
            {
                PublishDate = date;
            }
    
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
