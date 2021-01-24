        private bool _AutoSize = true;
 
        [Browsable(true)]
        new public bool AutoSize
        {
            get { return _AutoSize; }
            set
            {
                _AutoSize = value;
                UpdateStyles();
            }
        }
