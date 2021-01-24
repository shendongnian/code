There isn't a way to disable all events, because there are many event handlers set in the framework that you have no control over. You can prevent the user from triggering most events by setting [IsEnabled][1] to false though.
Detecting the difference between user interaction and programmatic change requires a bit of plumbing and the diligence to use it. Suppose you have a ComboBox, and you want to detect when only the user triggers [SelectionChanged][2]. This can be solved with a flag that's only ever true when you make programmatic changes. i.e.
    private bool isSelfUpdating;
    
    // Wrapped in a method for convenience.
    public void SetSelectedIndex(int index)
    {
        isSelfUpdating = true;
        comboBox.SelectedIndex = index;
        isSelfUpdating = false;
    }
    
    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (isSelfUpdating) return;
    
        // Assuming isSelfUpdating is set before every programmatic change, 
        // this point is reached only if the user changed the selection.
        // Your event handling code...
    }
Using such a technique requires that you **always** either use SetSelectedIndex or set isSelfUpdating prior to programmatic changes to ensure event handler(s) observe it and do nothing.
