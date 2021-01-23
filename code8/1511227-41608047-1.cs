    private void timer_move_Tick(object sender, EventArgs e)
    {            
        foreach (var button in ButtonList)
        {
            button.Location = CalculateMove(button.Location);
        }
    }
   
    private Point CalculateMove(Point currentLocation)
    {
        Point center = new Point(this.Width / 2, this.Height / 2);
        Point moveDestination = new Point();
        int stepsize = 20;
        moveDestination.X = currentLocation.X < center.X ? currentLocation.X + stepsize : currentLocation.X - stepsize;
        moveDestination.Y = currentLocation.Y < center.Y ? currentLocation.Y + stepsize : currentLocation.Y - stepsize;
        return moveDestination;
    }
