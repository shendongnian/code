             private string _ShowProgressRing;
        public bool ShowProgressRing 
        {
            get
            {
                return _ShowProgressRing;
            }
            set
            {
                this.Set<bool>("ShowProgressRing", ref this._ShowProgressRing, value);
            }
        }
