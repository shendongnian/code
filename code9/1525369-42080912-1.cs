    // store the current state:
    var valuesbefore = new List<object>();
    foreach (var r in this.GetType().GetFields(System.Reflection.BindingFlags.NonPublic))
        valuesbefore.Add(r.GetValue(this));
    // change the value the specified property
    PropertyChangedName = PropertyChangedName + "a"; 
      
    //get the new state of the class:
    var valuesnow = new List<object>();
    foreach (var r in this.GetType().GetFields(System.Reflection.BindingFlags.NonPublic))
        valuesnow.Add(r.GetValue(this));
    // check for any change
    bool equal = valuesbefore.SequenceEqual(valuesnow);
