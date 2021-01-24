    obj.MouseClick+= MouseClick;
    obj.MouseDoubleClick += MouseClick;
    // some stuff
    
    private void MouseClick(object sender, MouseEventArgs e)
    {
        if(e.Clicks == 2) { // handle double click }
    }
