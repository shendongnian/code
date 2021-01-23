         private string _ShowMessage ;
        public string ShowMessage 
        {
            get
            {
                return _ShowMessage;
            }
            set
            {
                this.Set<string>("ShowMessage ", ref this._ShowMessage , value);
            }
        }
