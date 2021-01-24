       private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                AdjustingTheForm = true;
            }
            else if (e.Button == MouseButtons.Right)
            {
                AdjustingTheForm = false;
            }
            LastLocation = PointToClient(e.Location);
        }
        private void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            scr = Screen.FromControl(this).WorkingArea;
            if (AdjustingTheForm)
            {
                if (FormNormalSize == false)
                {
                    FormNormalSize = true;
                    CustomForm_Resize(sender, e);
                    this.Location = new Point(Cursor.Position.X - 400, Cursor.Position.Y - 15);
                    this.Update();
                    LastLocation = PointToClient(e.Location);
                    MovingFormMaximized = true;
                }
                else
                {
                    MovingFormMinimized = true;
                }
                AdjustingTheForm = false;
            }
            if ((MovingFormMinimized && this.Location.Y > 0) || (MovingFormMinimized && this.Location.Y <= 0 && e.Y > 32))
            {
                mouseHuggingWall = false;
                this.Location = new Point(this.Location.X - LastLocation.X + e.X,
                    this.Location.Y - LastLocation.Y + e.Y);
                this.Update();
            }
            else if (MovingFormMinimized && this.Location.Y <= 0)
            {
                mouseHuggingWall = true;
                this.Location = new Point(this.Location.X - LastLocation.X + e.X, 0);
                this.Update();
            }
            if ((MovingFormMaximized && this.Location.Y > 0) || (MovingFormMaximized && this.Location.Y <= 0 && e.Y > 32))
            {
                mouseHuggingWall = false;
                this.Location = new Point(this.Location.X -LastLocation.X + e.X,
                    this.Location.Y - LastLocation.Y + e.Y);
                this.Update();
            }
            else if (MovingFormMaximized && this.Location.Y <= 0)
            {
                mouseHuggingWall = true;
                this.Location = new Point(this.Location.X - LastLocation.X + e.X, 0);
                this.Update();
            }
        }
        private void TopPanel_MouseUp(object sender, MouseEventArgs e)
        {
            scr = Screen.FromControl(this).WorkingArea;
            if(mouseHuggingWall == true)
            {
                FormNormalSize = false;
                CustomForm_Resize(sender, e);
            }
            MovingFormMinimized = false;
            MovingFormMaximized = false;
            mouseHuggingWall = false;
        }
