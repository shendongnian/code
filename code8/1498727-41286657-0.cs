        public System.Boolean None
        {
            get
            {
                if (!CommodityDescription && !CommoditySpanish)
                {
                    None= true;
                } 
                 
                else
                {
                    None= false;
                }
                return GetProperty(_NoneProperty); 
            }
            set
            {
                SetProperty(_NoneProperty, value);
            }
        }
