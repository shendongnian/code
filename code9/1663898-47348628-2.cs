        private const int maxLength = 5;
        private string _textToDisplay = "Hello SO";
        public string TextToDisplay
        {
            get
            {
                if(_textToDisplay.Length > maxLength)
                {
                    return _textToDisplay.Substring(0, maxLength);
                }
                return _textToDisplay;
            }
            set
            {
                _textToDisplay = value;
                RaiseProperyChanged();
            }
        }
