    class MyPBox : PictureBox
        {
        public MyPBox()
        {
            this.BackColor = Color.Red; // for see better
            this.Location = new Point(50, 50); // set location at form
           
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            if (this.Parent != null)
            {
                this.Parent.Paint += Parent_Paint; // picturebox's paint means it added to parent so we need to trigger parent's paint event
            }
            base.OnPaint(pe);
           
        }
        bool clickPerformed = false; // to catch control has mouse down
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            clickPerformed = true; // set mouse down
            Form tempSender =  this.Parent as Form; // get sender
            tempSender.Invalidate(); // invalidate to trigger paint event
        }
        private void Parent_Paint(object sender, PaintEventArgs e)
        {
            if (clickPerformed)
            {
                using (Graphics g = e.Graphics)
                {
                    using (Pen pen = new Pen(Color.Black, 2))
                    {
                        float locationX = this.Location.X + this.Size.Width / 2;
                        float locationY = this.Location.Y + this.Size.Height / 2;
                        float radius = (this.Size.Height + this.Size.Width) / 2;
                        float[] dashValues = { 5, 2, 15, 4 };
                        pen.DashPattern = dashValues;
                        DrawCircle(g, pen, locationX
                            , locationY
                            , radius); // draw circle 
                        clickPerformed = false; // process done so set it to false
                    }
                }
            }
            base.OnPaint(e);
           
        }
        
        protected override void OnMouseUp(MouseEventArgs e)
        {
            this.Parent.Invalidate(); // mouse up circle should be erased, so invalidate again to trigger paint, but this time clickPerformed is false
            // so it won't draw circle again
            base.OnMouseDown(e);
        }
        public void DrawCircle(Graphics g, Pen pen, float centerX, float centerY, float radius)
        {
            g.DrawEllipse(pen, centerX - radius, centerY - radius, radius + radius, radius + radius);
        }
        
    }
