     private bool _BoxCheckBool;
        //Updates value of _BoxCheckBool
        public bool BoxCheckBool
        {
            get
            {
                return _BoxCheckBool;
            }
            set
            {
                _BoxCheckBool = value;
                OnPropertyChanged("BoxCheckBool");
                if (_BoxCheckBool == true)
                {
                    BoxCheckString = "The Box has been checked";
                }
                else if (_BoxCheckBool == false)
                {
                    BoxCheckString = "The Box has not been checked";
                }
                else
                {
                    BoxCheckString = "ERROR";
                }
            }
        }
        //stores value (for textblock) 
        private string _BoxCheckString = "";
        public string BoxCheckString
        {
            //logic that determines what will be sent to the textblock
            get
            {
                return _BoxCheckString;
            }
            set
            { 
                _BoxCheckString = value;
                OnPropertyChanged("BoxCheckString");       
            }
        }
