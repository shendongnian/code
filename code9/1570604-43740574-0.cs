    private void TopPanel_MouseDown(object sender, MouseEventArgs e)
    {
        AdjustingTheForm = true;
        LastLocation1 = e.Location;
    }
    private void TopPanel_MouseMove(object sender, MouseEventArgs e)
    {
        scr = Screen.FromControl(this).WorkingArea;
        LastLocation2 = e.Location;
        if (AdjustingTheForm)
        {
            if (FormNormalSize == false)
            {
                FormNormalSize = true;
                CustomForm_Resize(sender, e);
                this.Location = new Point(LastLocation2.X - 400, LastLocation2.Y);
                this.Update();
                MovingFormMaximized = true;
            }
            else
            {
                this.Location = new Point(LastLocation1.X, LastLocation1.Y);
                MovingFormMinimized = true;
            }
            AdjustingTheForm = false;
        }
        if (MovingFormMinimized)
        {
            this.Location = new Point((this.Location.X - LastLocation1.X) + e.X,
                (this.Location.Y - LastLocation1.Y) + e.Y);
            this.Update();
        }
        else if(MovingFormMaximized)
        {
            this.Location = new Point(this.Location.X - 400 + e.X, this.Location.Y - 15 + e.Y);
            this.Update();
        }
    }
    private void TopPanel_MouseUp(object sender, MouseEventArgs e)
    {
        scr = Screen.FromControl(this).WorkingArea;
        MovingFormMinimized = false;
        MovingFormMaximized = false;
    }
