     public class PaymentViewModel : ViewModelBase
        {
    
            public PaymentViewModel()
            {            
                LoadClientGender();
            }
     private ObservableCollection<gender> _gendermappings = new ObservableCollection<gender>();
            public ObservableCollection<gender> gendermappings
            {
                get { return _gendermappings; }
                set
                {
                    _gendermappings = value;
                    OnPropertyChanged("gendermappings");
                }
            }
            private void LoadClientGender()
            {
                List<gender> genders = new List<gender>();
                genders.Add(new gender()
                {
                    GenderName = "Male",
                });
                genders.Add(new gender()
                {
                    GenderName = "Female",
                });
                genders.Add(new gender()
                {
                    GenderName = "Other",
                });
    
                genders.ForEach(_gendermappings.Add);
            }
        }
