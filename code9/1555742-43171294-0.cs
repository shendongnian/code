    public class Article
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
    }
    ...
    string[] list = Directory.GetFiles(@"Resources/", "*.png");
    List<Article> items = new List<Article>();
    foreach (var path in list)
    {
        items.Add(new Article()
        {
            Name = System.IO.Path.GetFileNameWithoutExtension(path),
            Path = path
        });
    }
    lvDataBinding.ItemsSource = items;
