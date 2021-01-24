      public string LogView
                {
                    get { return mLogViewStr; }
                    set
                    {
                        mLogViewStr = value;
                        OnPropertyChanged(LogView);
                    }
                }
