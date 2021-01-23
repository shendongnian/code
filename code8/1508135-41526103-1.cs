    public void Reset()
    {
      // Replaces any OneWay bindings
      // Updates MyValueSource for TwoWay bindings
      this.SetValue(MyValueProperty, 0);
    }
