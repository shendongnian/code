     public class DrugInfluence : INotifyPropertyChanged
        {
            public string Impairment { get; set; }
            
            private bool _isChecked;
            public bool IsChecked 
            { 
                get{ return _isChecked;}
                set
                {
                    if (_isChecked!= value)
                    {
                        _isChecked= value;
                        OnPropertyChanged("IsChecked");
                    }
                }; 
            }
        }
