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
                        _parent._isChecked = _isChecked ? true : _parent._isChecked;
                    }
                    RaisePropertyChanged("IsChecked");
                }
            }
