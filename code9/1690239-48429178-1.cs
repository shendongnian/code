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
