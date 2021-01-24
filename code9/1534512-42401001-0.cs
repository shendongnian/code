    var form = new Form();
    //This calculates the relative center of the parent, 
    //then converts the resulting point to screen coordinates.
    var relativeCenterParent = new Point(ActualWidth / 2, ActualHeight / 2);
    var centerParent = this.PointToScreen(relativeCenterParent);
    //This calculates the relative center of the child form.
    var hCenterChild = form.Width / 2;
    var vCenterChild = form.Height / 2;
    //Now we create a new System.Drawing.Point for the desired location of the
    //child form, subtracting the childs center, so that we end up with the child's 
    //center lining up with the parent's center.
    //(Don't get System.Drawing.Point (Windows Forms) confused with System.Windows.Point (WPF).)
    var childLocation = new System.Drawing.Point(
        (int)centerParent.X - hCenterChild,
        (int)centerParent.Y - vCenterChild);
    //Set the new location.
    form.Location = childLocation;
    
    //Set the start position to Manual, otherwise the location will be overwritten
    //by the start position calculation.
    form.StartPosition = FormStartPosition.Manual;
    
    form.ShowDialog();
