    List<Image> images = new List<Image>();
    for (int i = 0; i < files.Length; i++)
    {
       Image img = new Image() {ImagePath = files[i]};
       images.Add(img);
    }
    string json = JsonConvert.SerializeObject(images);
