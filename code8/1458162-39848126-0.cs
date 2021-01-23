        get { return _text; }
        set
        {
            if (value != _text)
            {
                _text = value;
                Parent.IsChanged = true;
                OnPropertyChanged("Text");
            }
        }
