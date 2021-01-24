    Image img = Image.FromFile(path);
    Size size = img.Size;
    //CREATE EMPTY BITMAP TO DRAW ON IT
    using (Bitmap save = new Bitmap(size.Width, size.Height))
    {
        using (Graphics g = Graphics.FromImage(save))
        {
            //DRAWING...
            //SAVING TO FILE
            g.Flush();
            save.Save("file.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            g.Dispose();
        }
    }
