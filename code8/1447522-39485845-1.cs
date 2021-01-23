        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                if (_parent == null)
                {
                    foreach (MenuItem Child in _subItems)
                    {
                        Child._isChecked = this._isChecked;
                        Child.RaisePropertyChanged("IsChecked");
                    }
                }
                if (_parent != null)
                {
                    _parent.NotifyChecked(_isChecked);
                }
                RaisePropertyChanged("IsChecked");
            }
        }
        public void NotifyChecked(bool childChecked) 
        { 
           _isChecked = childChecked;
            RaisePropertyChanged("IsChecked"); 
           if (_parent != null)
           {
               _parent.NotifyChecked(_isChecked);
           }
        }
