    using (Bitmap im = new Bitmap(chart1.Width, chart1.Height))
    {                
        chart1.DrawToBitmap(im, new Rectangle(0, 0, chart1.Width, chart1.Height));
        using (Graphics gr = Graphics.FromImage(im))
        {
            gr.DrawString("Test", 
                new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), 
                new SolidBrush(Color.Red), new PointF(10, 10));
        }
        im.Save(path);                                    
    }
