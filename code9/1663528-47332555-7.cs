      public void WhenMouseMove()
            {
                //Do stuff
                Console.WriteLine(Name);
            }
    
            private RelayCommand _MouseHoveredItemChangedCommand;
            public RelayCommand MouseHoveredItemChangedCommand
            {
                get
                {
                    if (_MouseHoveredItemChangedCommand == null)
                    {
                        _MouseHoveredItemChangedCommand = new RelayCommand(WhenMouseMove);
                    }
                    return _MouseHoveredItemChangedCommand;
                }
            }
