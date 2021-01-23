    Internal Class TestResult
    {
      ...
      private bool _canUpload;
      public bool CanUpload
      {
        get { return _canUpload; }
        set
        {
          _canUpload = value;
          base.RaisePropertyChanged("CanUpload");
        }
      }
    }
