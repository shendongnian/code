    private string _Prop = "";
    public string Prop
    {
      get { return _Prop; }
      set { Set(nameof(Prop), ref _Prop, value); }
    }
