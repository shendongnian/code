    public class ViewModel : INotifyPropertyChanged
    {
        public List<string> Sites
        {
            get
            {
                return new List<string>()
                {
                    "Miami",
                    "Texas"
                };
            }
        }
        private string _selectedContractSite = "Texas";
        public string SelectedContractSite
        {
            get
            {
                return _selectedContractSite;
            }
            set
            {
                if (_selectedContractSite != value)
                {
                    _selectedContractSite = value;
                    OnPropertyChanged(nameof(SelectedContractSite));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
