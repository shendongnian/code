    private void TextButton(Button btn, string line1, string line2)
    {
        btn.Text = String.Empty;
        Bitmap bmp = new Bitmap(btn.ClientRectangle.Width, btn.ClientRectangle.Height);
        using (Graphics G = Graphics.FromImage(bmp))
        {
            G.Clear(Color.Transparent);          <----- I have set this
			G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit; <--- This to avoid bad text within bitmap
			G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;     <--- Also this to avoid bad text within bitmap
            StringFormat SF = new StringFormat();               
            SF.Alignment = StringAlignment.Center;
            SF.LineAlignment = StringAlignment.Near;
            using (Font tahoma = new Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold))
            {
                Rectangle RC = new Rectangle(btn.ClientRectangle.X, btn.ClientRectangle.Y + 30, btn.ClientRectangle.Width, btn.ClientRectangle.Height-30);                 
                RC.Inflate(-5, -5);
               
                G.DrawString(line1, tahoma, Brushes.Black, RC, SF);                 
            }
            using (Font tahoma2 = new Font("Tahoma", 12))
            {   
                Rectangle RC = new Rectangle(btn.ClientRectangle.X, btn.ClientRectangle.Y + 30, btn.ClientRectangle.Width, btn.ClientRectangle.Height-30);
                RC.Inflate(-5, -5);
                SF.LineAlignment = StringAlignment.Center;                
                G.DrawString(line2, tahoma2, Brushes.Red, RC, SF);
            }
        }
        btn.Image = bmp;
        btn.ImageAlign = ContentAlignment.MiddleCenter;
    }
