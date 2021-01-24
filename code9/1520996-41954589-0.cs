            public class MenuModel : ViewModelBase
            {
                // Other pieces of code....
                private bool _sw_reportes;
                public bool Sw_reportes
                {
                    get { return _sw_reportes; }
                    set { _sw_reportes = value; 
                           RaisePropertyChanged(() => Sw_reportes); }
                }
            }
