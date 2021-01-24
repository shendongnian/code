    private void DrawPb_MouseWheel(object sender, MouseEventArgs e)
        {
            // e contains current mouse location and the wheel direction
            int wheelDirection = e.Delta / Math.Abs(e.Delta); // is 'in' or 'out' (1 or -1).
            double factor = Math.Exp(wheelDirection * Constants.ZoomFactor); // divide or multiply
            double newX = e.X - e.X / factor; // what used to be x is now newX
            double newY = e.Y - e.Y / factor; // same for y
            Point offset = new Point((int)(-newX), (int)(-newY)); // the offset of the old point to it's new location
            Graph.AddOffset(offset); // apply offset
        }
