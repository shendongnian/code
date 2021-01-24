    public Vehicle(List<Properties> defaultProps) 
    {
      property = new List<Properties>();
      foreach (var p in defaultProps)
      {
        var newProp = new Properties {
                                        maxSpeed = p.maxSpeed,
                                        isTwoDoor = p.isTwoDoor
                                        // add any other properties here
                                     };
        property.Add(newProp);
      }
    }
