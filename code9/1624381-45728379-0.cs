     public string SearchText
     {
         private set
         {
              if (Text.Length >= 3)
               return;
              _text = value;
              OnPropertyChanged("SearchText");
         }
         get
         {                    
            return _text;    
         }
     }
