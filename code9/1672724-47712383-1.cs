    using GalaSoft.MvvmLight;
    
    namespace WpfApp1
    {
        public class Phase : ViewModelBase
        {
            private int _priorite;
    
            public int Priorite
            {
                get { return _priorite; }
                set
                {
                    _priorite = value;
                    RaisePropertyChanged(() => Priorite);
                }
            }
        }
    }
