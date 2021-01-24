    public string Reason
        {
            get
            {
                return this.reason;
            }
            set
            {
                this.reason = string.IsNullOrEmpty(value)
                  ? "reason not explicited"
                  : value; 
            }
        }
