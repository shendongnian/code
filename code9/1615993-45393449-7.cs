    foreach (Control control in Controls)
    {
        if (control is PathControl)
        {
            // use a clone, so the original path won't be changed!
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
