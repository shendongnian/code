    private void Form2_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        Pen myPen = new Pen(Brushes.Red, 7);
        Pen myPen2 = new Pen(Brushes.Green, 7);
            
        int endX = this.ClientRectangle.Width;
        int endY = this.ClientRectangle.Height;
            
        int xCenter = this.ClientRectangle.Left + (this.ClientRectangle.Width / 2);
        int yCenter = this.ClientRectangle.Top + (this.ClientRectangle.Height / 2);
        Pen circlePen = new Pen(Brushes.Black, 9);
        Font myFont = new Font("Monotype Corsiva", 43, FontStyle.Bold);
        g.DrawString("Happy Face", myFont, Brushes.Aqua, 300, 25);
            
        g.DrawEllipse(circlePen, xpos, ypos, 250, 250);
        g.FillEllipse(Brushes.PeachPuff, xpos, ypos, 250, 250);
        g.DrawEllipse(circlePen, xpos + 65, ypos -130  + 200, 20, 35);
        g.FillEllipse(Brushes.Black, xpos + 65, ypos-130 + 200, 20, 35);
        g.DrawEllipse(circlePen, xpos + 160, ypos-130 + 200, 20, 35);
        g.FillEllipse(Brushes.Black, xpos + 160, ypos-130 + 200, 20, 35);
        g.DrawArc(circlePen, xpos + 60, ypos-130 + 215, 130, 120, 35, 115);
    }
