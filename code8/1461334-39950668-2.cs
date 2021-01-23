        /// <summary>
        /// Text is in MainWindowViewModel
        /// </summary>
        public string Text 
        {
            get { return _text;}
            set
            {
                if(value !=_text)
                {
                    _text = value;
                    //User control1 has Text property in its view model
                    Uc1Vm.Text = _text;
                    //User control2 has Content property in its view model
                    Uc2Vm.Content = _text;
                    if(PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Text"));
                    }
                }
            }
        }
