        public class Feature : ReactiveObject // this contains INotifyPropertyChanged and so on
        {
         public string Name
                {
                    get { return _name; }
                    set { this.RaiseAndSetIfChanged(ref _name, value); }
                }
        
         public bool Checked
                {
                    get { return _checked; }
                    set { this.RaiseAndSetIfChanged(ref _checked, value); }
                }
    
     public bool Enabled
                {
                    get { return _enabled; }
                    set { this.RaiseAndSetIfChanged(ref _enabled, value); }
                }
        }
