         private string _text;   //string that is used as a reference which you can plug your new new window
        public string Text
        {
            get
            {
                return this._text;
            }
            set
            {
                this._text = value;
                if (null != PropertyChanged)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs  ("Text"));
                }
            }
        }
