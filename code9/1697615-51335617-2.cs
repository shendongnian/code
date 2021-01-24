        private bool enableGpRibbonNesting;
        public bool EnableGpRibbonNesting
        {
            get { return enableGpRibbonNesting; }
            set
            {
                enableGpRibbonNesting = value;
                this.NotifyPropertyChanged("EnableGpRibbonNesting");
            }
        }
        private string enableGpRibbonNestingReason;
        public string EnableGpRibbonNestingReason
        {
            get { return enableGpRibbonNestingReason; }
            set
            {
                enableGpRibbonNestingReason = value;
                if (value == "")
                {
                    EnableGpRibbonNesting = true;
                }
                else
                {
                    EnableGpRibbonNesting = false;
                }
                this.NotifyPropertyChanged("EnableGpRibbonNestingReason");
            }
        }
        
