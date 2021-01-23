     private bool _expanderEnable;
     public bool ExpanderEnable {
         get 
         { 
             return _expanderEnable; //Breakpoint2
         }
         set {
             if (value == _expanderEnable) return; //BreakPoint1
             _expanderEnable = value;
             OnPropertyChanged();
         }
     }
    
    public event PropertyChangedEventHandler PropertyChanged;
    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
