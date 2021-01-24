Disabling all events isn't possible because there are many event handlers in the framework that you have no direct control over. That said, you can prevent the user from triggering most events by setting [IsEnabled][1] to false.
Detecting the difference between user interaction and programmatic change requires a bit of plumbing and the diligence to use it everywhere. Suppose you have a ComboBox, and you want to detect when the user triggers [SelectionChanged][2]. This can be done with a flag, set only when you make programmatic changes. i.e.
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
    
        // When isSelfUpdating is set before every programmatic change, 
        // handlers like this will only run if the user changed the selection.
        // Your event handling code...
    }
Using this technique requires that you **always** either use SetSelectedIndex or set/reset isSelfUpdating around programmatic changes to ensure event handler(s) observe it and do nothing.
