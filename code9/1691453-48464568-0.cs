    public TP1CustomFlatButton()
    {
        this.FlatStyle = FlatStyle.Flat;
        this.FlatAppearance.BorderSize = 0;
        this.BackColor = Color.MediumSeaGreen;
        this.ForeColor = Color.White;
        this.Text = "middle";
    }
    
    protected override void OnPaint(PaintEventArgs pevent)
    {
        pevent.Graphics.FillRectangle(new SolidBrush(this.BackColor), new Rectangle(0, 0, this.Width, this.Height));
        TextFormatFlags flags = TextFormatFlags.Bottom;
    
        //render text
        String drawString = this.Text;
        SizeF size = pevent.Graphics.MeasureString(drawString, this.Font);
        Point drawPoint = new Point((int)this.Size.Width / 2 - (int)size.Width / 2,this.Height);
        TextRenderer.DrawText(pevent.Graphics, this.Text, this.Font, drawPoint, this.ForeColor, flags);
    
        //draw image
        Image img = this.BackgroundImage;
    
        //create rectangle to display image
        Rectangle imgRec = new Rectangle(this.Width - 32 / 3, this.Height - 32 / 3, 32, 32);
    
        if (img != null)
            pevent.Graphics.DrawImage(img, imgRec);
    
    }
