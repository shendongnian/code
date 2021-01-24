    foreach (Control control in Controls)
    {
        if (control is PathControl)
        {
            GraphicsPath gp = (GraphicsPath)(control as PathControl).path.Clone();
 
            Matrix matrix = new Matrix();
            matrix.Translate(control.Left, control.Top);
            gp.Transform(matrix);  // here we move by the location offsets
            region.Union(gp);
        else
        {
            region.Union(control.Bounds);
        }
    }
