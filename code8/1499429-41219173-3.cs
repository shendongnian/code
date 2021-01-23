    var files = Directory.GetFiles(Server.MapPath("~/AppImages/12162016/"));
    List<Image> images = new List<Image>();
    foreach (var file in files)
    {
        images.Add(Image.FromFile(file));
    }
    MergeImages(images.ToArray());
   
