      var dataUrl = "";
      using (System.Drawing.Image s = CreateBitmapImage("Hi"))
      {
        ImageConverter converter = new ImageConverter();
        var imageBytes = (byte[])converter.ConvertTo(s, typeof(byte[]));
        var b64String = Convert.ToBase64String(imageBytes);
        dataUrl = "data:image/jpg;base64," + b64String;
      }
      var htmlContent = "<img src=\"" + dataUrl + "\" />";
