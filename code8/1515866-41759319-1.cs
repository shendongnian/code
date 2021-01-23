    public bool PasteDimensions
      {
         get { return pasteDimensions; }
         set
         {
            pasteDimensions = value;
            RaisePropertyChanged("PasteDimensions");
            RaisePropertyChanged("IsViewGridVisible");
         }
      }
