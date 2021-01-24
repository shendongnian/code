    Public TimeSpan MediaPosition
    {
       get { return _mediaPosition; }
       set
       {
          _mediaPosition = value;
          PropertyChanged("MediaPosition");
       } 
    }
