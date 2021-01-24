    private void panelDrawLD_Paint(object sender, PaintEventArgs e)
    {
        //e.Graphics does NOT need to be disposed of because *we* did not create it, it was passed to us by the control its self.
    	DrawStuff(e.Graphics);
    }
    
    private void Save()
    {
        // I_LD, and g are both GDI objects that *we* created in code, and must be disposed of.  The "using" block will automatically call .Dispose() on the object when it goes out of scope.
    	using (Bitmap I_LD = new Bitmap(panelDrawLD.Size.Width, panelDrawLD.Size.Height))
        {
    	    using (Graphics g = Graphics.FromImage(I_LD))
    	    {
    		    DrawStuff(g);
            }
            I_LD.Save(tempPath + "I_LD.bmp", ImageFormat.Bmp); 
        }   
    }
    
    
    private void DrawStuff(Graphics target)
    {
    	//Code example
    	target.FillPolygon(blackBrush, getPoints(min, sizeGP, scaleX, scaleY));
    	target.FillPolygon(blackBrush, getPoints(max, sizeGP, scaleX, scaleY));
    }
