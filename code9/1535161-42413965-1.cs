    public class SystemInformation : ViewModelBase
    {
        private ObservableCollection<Site> _activeSites;
        private RelayCommand _updateAllCommand;
        public SystemInformation() : base()
        {
            ActiveSites = new ObservableCollection<Site>();
            View = CollectionViewSource.GetDefaultView(ActiveSites);
        }
        public System.ComponentModel.ICollectionView View { get; private set; } //<-- bind to this one
        public ObservableCollection<Site> ActiveSites
        {
            get
            {
                return _activeSites;
            }
            set
            {
                Set("ActiveSites", ref _activeSites, value);
            }
        }
        public RelayCommand UpdateAllCommand
        {
            get
            {
                return _updateAllCommand
                  ?? (_updateAllCommand = new RelayCommand(() => 
                  {
                      foreach (var site in View.OfType<Site>())
                      {
                          //---
                      }
                  }));
            }
        }
    }
----------
    <igDP:XamDataGrid ... DataSource="{Binding View}" />
    
