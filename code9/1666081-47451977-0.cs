       WPicture picture = item as WPicture;
      //Load the DocIO WPicture image bytes into CoreCompat Image instance.
      Image image = Image.FromStream(new MemoryStream(picture.ImageBytes));
      //Check image format, if format is other than png then convert the image as png format.
      if (!image.RawFormat.Equals(ImageFormat.Png))
      {
          MemoryStream imageStream = new MemoryStream();
          image.Save(imageStream, ImageFormat.Png);
          //Load the png format image into DocIO WPicture instance.
          picture.LoadImage(imageStream);
          imageStream.Dispose();
       }
       //Resize the picture width and height.
       picture.Width = 400;
       picture.Height = 400;
 
