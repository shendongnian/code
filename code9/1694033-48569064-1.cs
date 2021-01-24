    private string LoadImage(string imagePath) {
      return Image.FromFile(MapImagePath(imagePath));
    }
    
    private string MapImagePath(string imagePath) {
      if (string.IsNullOrEmpty(imagePath))
        imagePath = GetNoImagePath();
      else {
        if (!File.Exists(imagePath))
          imagePath = GetNoImagePath();
      }
      return imagePath;
    }
    
    private string GetNoImagePath() {
      return "D:\ProjectFolder\Images\NoImage.png";
    }
