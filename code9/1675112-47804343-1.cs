    private void gdEnglish_MouseLeave(object sender, MouseEventArgs e)
    {
        gdEnglish_clickflag = false;
    }
    
    private void gdEnglish_MouseUp(object sender, MouseButtonEventArgs e)
    {
        if (gdEnglish_clickflag)
        {
            gdEnglish_clickflag = false;
            e.Handled = true;
                //////////
                // YOUR //
                // CODE //
                //////////
            }
        }
    
    private void gdEnglish_MouseDown(object sender, MouseButtonEventArgs e)
    {
        gdEnglish_clickflag = true;
    }
    
    private void gdEnglish_TouchLeave(object sender, TouchEventArgs e)
    {
        gdEnglish_clickflag = false;
    }
    
    private void gdEnglish_TouchUp(object sender, TouchEventArgs e)
    {
        if (gdEnglish_clickflag)
        {
            gdEnglish_clickflag = false;
            e.Handled = true;
    
            //////////
            // YOUR //
            // CODE //
            //////////
        }
    }
    
    private void gdEnglish_TouchDown(object sender, TouchEventArgs e)
    {
        gdEnglish_clickflag = true;
    }
