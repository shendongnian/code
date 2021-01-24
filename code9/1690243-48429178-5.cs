Disabling all events isn't possible because there are many event handlers in the framework that you have no direct control over. That said, you can prevent the user from triggering most events by setting [IsEnabled][1] to false.
Detecting the difference between user interaction and programmatic change requires a bit of plumbing and the diligence to use it everywhere. Suppose you have a ComboBox, and you want to detect when the user triggers [SelectionChanged][2]. This can be done with a flag, set only when you make programmatic changes. i.e.
    private bool blockHandlers;
    
    // Wrapped in a method for convenience.
    public void SetSelectedIndex(int index)
    {
        blockHandlers = true;
        comboBox.SelectedIndex = index;
        blockHandlers = false;
    }
    
    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (blockHandlers) return;
    
        // Your event handling code...
    }
Using this technique requires that you **always** either use SetSelectedIndex or set/reset blockHandlers around programmatic changes to ensure event handler(s) observe it and do nothing.
