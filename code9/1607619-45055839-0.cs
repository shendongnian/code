            private int? getHeight = null;
            public int? GetHeight
            {
                get { return getHeight; }
                set
                {
                    if (!getHeight.HasValue || (!getHeight.Equals(value) && value.Value <= 250))
                    {
                        getHeight = value;
                    }
                    else
                    {
                        getHeight = 0;
                        value = 0; //override the value
                    }
    
                    // validate against our value for the property change.
                    if (value.HasValue && value != null)
                    {
                        OnPropertyChanged();
                    }
                }
            }
