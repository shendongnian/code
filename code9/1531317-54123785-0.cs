    using System.Drawing;
    // ...
    public bool IsImage(byte[] data)
    {
      var dataIsImage = false;
      using (var imageReadStream = new MemoryStream(data))
      {
        try
        {
          using (var possibleImage = Image.FromStream(imageReadStream))
          {
          }
          dataIsImage = true;
        }
        // Here you'd figure specific exception to catch. Do not leave like that.
        catch
        {
          dataIsImage = false;
        }
      }
      
      return dataIsImage;
    }
