     public class gender:Base
        {
    
            private String _GenderName = String.Empty;
            public String GenderName
            {
                get { return _GenderName; }
                set
                {
                    if (_GenderName != value)
                    {
                        _GenderName = value;
                        OnPropertyChanged("GenderName");
                    }
                }
            }
        }
