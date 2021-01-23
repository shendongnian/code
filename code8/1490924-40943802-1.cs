    private void SecondaryToggle_Toggled(object sender, RoutedEventArgs e)
    {
    if (SecondaryToggle.IsOn == true)
        {
            // Here we save the state of the Child toggles 
            // before setting them to a different setting
            child1var = Child1Toggle.IsOn;
            child2var = Child2Toggle.IsOn;
            child3var = Child3Toggle.IsOn;
            child4var = Child4Toggle.IsOn;
            Child1Toggle.IsOn = true;
            Child2Toggle.IsOn = true;
            Child3Toggle.IsOn = false;
            Child4Toggle.IsOn = false;
        }
