     public class SoftwareVersionListViewModel : ViewModelBase
        {
            public SoftwareVersionListViewModel()
            {
                GetSW();
            }
    
            //Define the observable collection
            private ObservableCollection<SoftwareDefEntity> _SWmappings2 = new ObservableCollection<SoftwareDefEntity>();
    
            //here is  your Entity list
            public List<SoftwareDefEntity> SWentities
            {
                get;
                set;
            }
    
            // Obeservable collection property for access
            public ObservableCollection<SoftwareDefEntity> SWmappings2
            {
                get { return _SWmappings2; }
                set
                {
                    _SWmappings2 = value;
                    OnPropertyChanged("appeventmappings2");
                }
            }
    
            /// <summary>
            ///  load the combobox
            /// </summary>
           private void GetSW() // Method that reads the data from the service layer
            {
            SWDefService obj = new SWDefService();
            SWentities = obj.getSW(); //getSW is the method refered in Service layer
            SWentities.ForEach(_SWmappings2.Add);
            }
        }
