You can detect the difference between user interaction and programmatic change with a bit of plumbing and the diligence to use it everywhere that it matters. Suppose you have a ComboBox, and you want to detect when the user triggers [SelectionChanged][1]. This can be done with a flag, set only when you make programmatic changes. i.e.
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
