    public Load
    {    
        public DelegateCommand<object> _clickCommand;
        public DelegateCommand<object> ClickCommand    
        {
           get
           {
               if (_clickCommand == null)
                   _clickCommand = new DelegateCommand<object>(OnClickCommandRaised);
               return _clickCommand;
           }
        }
        public void OnClickCommandRaised(object obj)
        {
            //Your click logic.
        }
    }
 
