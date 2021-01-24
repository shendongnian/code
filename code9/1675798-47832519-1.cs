    public Action OKFunction
    {
      get { return (Action)Delegate.CreateDelegate(typeof(Action), this, 
                             ((Action)_session.Thingy).Method); }
      set { _session.Thingy = value; }
    }
