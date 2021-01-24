    string nameOfPropertyToBeBound = "Whatever";
    Binding bdg = new Binding(nameOfPropertyToBeBound);
    //  No-op
    //bdg.NotifyOnTargetUpdated = true;
    //  Is this a read-only column? If it's read-only, this is a no-op
    bdg.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
    //  Is this a read-only column? If it's read-only, this is a no-op
    bdg.Mode = BindingMode.TwoWay;
