    public class MyViewModel : INotifyPropertyChanged
    {        
        private Data _data;
        public string ID
        {
            get { return _data.Id;}
            set 
            {
                if(_data.Id != value)
                {
                    _data.Id = value;
                    NotifyPropertyChanged();
                }
            }
        }
        // Same stuff for the other properties
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName]String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void SearchInDb(string id)
        {
            // request data to sql server database
            // and then populate a Data Class Object with the data retrieved
            // from database:
            _data = new Data()
            {                            
                Id = sReader[0].ToString().Trim(),
                Name = sReader[1].ToString().Trim(),
                Description = sReader[2].ToString().Trim()
            };
            NotifyPropertyChanged(nameof(ID));
            NotifyPropertyChanged(nameof(Name));
            NotifyPropertyChanged(nameof(Description));
        }
    }
