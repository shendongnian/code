     public int cursorPos
        {
            get 
            { return position; 
            }
            set
            {
                postion = value;  // if you call for example "cursorPos = 12;" the value is "12". this is how properties work...
                RaisePropertyChanged(nameof(cursorPos));
            }
        }
