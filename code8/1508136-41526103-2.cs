    public void Reset()
    {
      // this.SetValue(MyValueProperty, 0); // Replaces the binding
      this.SetCurrentValue(MyValueProperty, 0); // Keeps the binding
    }
