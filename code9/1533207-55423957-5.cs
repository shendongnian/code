     System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(
    				this.picUser.ClientRectangle, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.DeepSkyBlue, 70);
    
    using (System.Drawing.Font myFont = new System.Drawing.Font("Arial", 28, System.Drawing.FontStyle.Bold))
    				this.picUser.Image = DrawUserCircle(new System.Drawing.Size(64, 64), brush, "JC", myFont, System.Drawing.Color.White);
