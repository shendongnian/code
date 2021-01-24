    protected virtual void OnProgressChanged(CustomEventArgs e)
    {
      if (ProgressChanged != null)
      {
        ProgressChanged(this, new CustomEventArgs() { MyValue = e.MyValue });
      }
    }
