             private string _IsBusy ;
        public bool IsBusy
        {
            get
            {
                return _IsBusy ;
            }
            set
            {
                this.Set<bool>("IsBusy ", ref this._IsBusy , value);
            }
        }
