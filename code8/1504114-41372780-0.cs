    // In StuffService class:
    public async Task<Result> FetchAsync()
    {
      //network stuff
      return result;
    }
    // In StuffViewModel class:
    public async void ButtonClicked()
    {
      foreach (var stuff)
      {
        var result = await Task.Run(() => _stuffService.FetchAsync());
        MyProperty = result.MyProperty;
        count += result.Count;
      }
      if (count == 0)
        //...
    }
    public Property MyProperty
    {
      get { return _myProperty; }
      set
      {
        _myProperty = value;
        RaisePropertyChanged();
      }
    }
    private void RaisePropertyChanged([CallerMemberName] string pChangedProperty = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(pChangedProperty));
    }
