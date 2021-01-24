    // open the image
    using (Image image = Image.FromFile(@"c:\sourceimage.jpg"))
    {
      // create a new bitmap with original image
      Bitmap imageWithWatermark = new Bitmap(image);
    
      using (Graphics gr = Graphics.FromImage(imageWithWatermark))
      {
        // draw the watermark
        gr.DrawImage(Image.FromFile(@"c:\watermark.png"), new Point(0, 0));
      }
      
      imageWithWatermark.Save(@"c:\destimage.jpg", ImageFormat.Jpeg);
    }
