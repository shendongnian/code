    public void IsMarked_Checked(object sender, RoutedEventArgs e)
    {
        var ck = sender As Checkbox;
    
        if (ck == null) 
        {
             return;
        }
    
        // do whatever you need to here using the datacontext of the Checkbox
    }
