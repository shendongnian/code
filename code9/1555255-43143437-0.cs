        //This first copy/paste is to convert from chart to image
        chartObj.CopyPicture();
        xlWorksheet5.Paste();
        //This image has decent resolution
        xlWorksheet5.Shapes.Item(xlWorksheet5.Shapes.Count).Copy();
        //Save the image
        System.Windows.Media.Imaging.BitmapEncoder enc = new System.Windows.Media.Imaging.BmpBitmapEncoder();
        enc.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(System.Windows.Clipboard.GetImage()));
        using (System.IO.MemoryStream outStream = new System.IO.MemoryStream())
        {
            enc.Save(outStream);
            System.Drawing.Image pic = new System.Drawing.Bitmap(outStream);
            pic.Save("image.png");
        }
