    System.Drawing.Image GetImageToDisplay()
    {
         FileStream imageStream = new FileStream(this.GetImageFileName(), FileMode.Open);
         System.Drawing.Image image = new Image(imageStream);
         return image;
    }
