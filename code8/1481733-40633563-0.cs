    public string FirstName {
      get { return mFirstName; }
      set {
        if (mFirstName == value) return;
        mFirstName = value;
        OnPropertyChanged();
      }
    }
