    System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
    System.Drawing.Graphics formGraphics;
    formGraphics = this.CreateGraphics();
    formGraphics.FillRectangle(myBrush, new Rectangle(0, 0, 200, 300));
    myBrush.Dispose();
    formGraphics.Dispose();
