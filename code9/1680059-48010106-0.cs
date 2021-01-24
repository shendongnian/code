    public class Rights : ViewModelBase
    {
        private bool _sales;
        public bool Sales {
            get { return _sales; }
            set { SetRightFlag(ref _sales, value); }
        }
        private bool _product;
        public bool Product
        {
            get { return _product; }
            set { SetRightFlag(ref _product, value); }
        }
        private bool _zone;
        public bool Zone
        {
            get { return _zone; }
            set { SetRightFlag(ref _zone, value); }
        }
        private bool _percentage;
        public bool Percentage
        {
            get { return _percentage; }
            set { SetRightFlag(ref _percentage, value); }
        }
        private bool _user;
        public bool User
        {
            get { return _user; }
            set { SetRightFlag(ref _user, value); }
        }
        //  This logic needs to happen in five different setters, so I put it in a 
        //  method. 
        private bool SetRightFlag(ref bool field, bool value, [System.Runtime.CompilerServices.CallerMemberName] string propName = null)
        {
            if (field != value)
            {
                Set(ref field, value, propName);
                UpdateAll();
                return true;
            }
            return false;
        }
        //  I made this its own method as well, for cleanliness and clarity, even though 
        //  it's only called once. 
        protected void UpdateAll()
        {
            //  Don't call the All setter from here, because it has side effects.
            if (User && Percentage && Zone && Product && Sales)
            {
                _all = true;
                OnPropertyChanged(nameof(All));
            }
            else if (!User && !Percentage && !Zone && !Product && !Sales)
            {
                _all = false;
                OnPropertyChanged(nameof(All));
            }
            else if (All.HasValue)
            {
                _all = null;
                OnPropertyChanged(nameof(All));
            }
        }
        private bool? _all = null;
        public bool? All
        {
            get { return _all; }
            set {
                if (_all != value)
                {
                    Set(ref _all, value);
                    if (_all.HasValue)
                    {
                        User = Percentage = Zone = Product = Sales = (bool)_all;
                    }
                }
            }
        }
    }
