    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<string> Names { get; set; } = new ObservableCollection<string>() {"A", "B", "C"};
        #region SelectedName
        private string selectedName;
        public string SelectedName
        {
            get
            {
                return selectedName;
            }
            set
            {
                if (value != selectedName)
                {
                    selectedName = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion
        #region ListItemClickCommand
        private ICommand listItemClickCommand;
        public ICommand ListItemClickCommand
        {
            get
            {
                if (listItemClickCommand == null)
                {
                    listItemClickCommand = new RelayCommand(OnListItemClick);
                }
                return listItemClickCommand;
            }
        }
        void OnListItemClick(object param)
        {
            Names.Remove(SelectedName);
        }
        #endregion
    }
