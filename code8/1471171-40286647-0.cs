        Graphics g = pictureBox.GetGraphics; // get the picture box graphics (i doubt this line compile but you get the idea of the object you need)    
        using (Bitmap bmp = new Bitmap("img.bmp")) // or the image currently in the picture box
        {        
            // create the color map
            var colorMap = new ColorMap[1];
            colorMap[0] = new ColorMap();
            
            // old color
            colorMap[0].OldColor = Color.Black;
            // replaced by this color
            colorMap[0].NewColor = Color.Purple;
            // attribute to remap the table of colors
            var att = new ImageAttributes();
            att.SetRemapTable(colorMap);
            // draw result
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            g.DrawImage(bmp, rect, 0, 0, rect.Width, rect.Height, GraphicsUnit.Pixel, att);
        }
    
