        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                RaisePropertyChanged("IsChecked");
                if (Parent == null)
                {
                    foreach (MenuItem Child in _subItems)
                        Child.CheckedHelper(this.IsChecked);
                }
                if (Parent != null)
                {
                    Parent.IsChecked = IsChecked ? true :Parent.IsChecked;
                }
            }
        }
        public void CheckedHelper(bool IsParentChecked)
        {
           this.IsChecked = isParentChecked;
           foreach (MenuItem Child in _subItems)
                 Child.CheckedHelper(this.IsChecked);
        }
