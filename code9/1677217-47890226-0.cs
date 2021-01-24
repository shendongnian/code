    private void Form1_KeyPress(object sender, KeyPressEventArgs e)
    {
       if(e.KeyChar=='K')
       Draw();
    }
    void Draw()
    {
       System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Black);
       System.Drawing.Graphics formGraphics;
       formGraphics = this.CreateGraphics();
       formGraphics.DrawLine(myPen, 0, 0, 200, 200);
       myPen.Dispose();
       formGraphics.Dispose();
    }
