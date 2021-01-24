    public void InvokeIfNeeded(Action action)
    {
      if (this.InvokeRequired)
        Invoke(action);
      else
        action(); // direct call   
    }
