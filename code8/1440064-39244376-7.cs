     private bool _expanderEnable;
     public bool ExpanderEnable {
         get { return _expanderEnable; }
         set {
             if (value == _expanderEnable) return;
             _expanderEnable = value;
             NotifyOfPropertyChange(() => ExpanderEnable); // could be replace by (in your case):
             // OnPropertyChanged();
         }
     }
