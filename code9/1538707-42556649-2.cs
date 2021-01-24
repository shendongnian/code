    public Form1()
    {
        InitializeComponent();
    }
    private async void Form1_Load(object sender, EventArgs e)
    {
        progressBar1.Visible = true;
        progressBar1.Value = 0;
        await LoadImages();
        progressBar1.Visible = false;
    }
    // Just represents a simple source-target mapping so you can associate the loaded images with their targets
    // Here I use a path-control mapping just for the case of the example
    private ICollection<KeyValuePair<string, Control>> GetImageMapping()
    {
        var basePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures), "Sample Pictures");
        var mapping = new Dictionary<string, Control>
        {
            [Path.Combine(basePath, "Tulips.jpg")] = this, // form1
            [Path.Combine(basePath, "Chrysanthemum.jpg")] = button1,
            // etc, eg. myUserControl1...
        };
        return mapping;
    }
    private async Task LoadImages()
    {
        var mapping = GetImageMapping();
        progressBar1.Maximum = mapping.Count;
        foreach (var item in mapping)
        {
            var image = await LoadImage(item.Key);
            item.Value.BackgroundImage = image;
            progressBar1.Value++;
        }
    }
    private async Task<Image> LoadImage(string imagePath)
    {
        // This makes 1s delay for each image to imitate slow loading. You do NOT need this line actually.
        await Task.Delay(1000);
        // Only this part will be executed in another thread:
        return await Task.Run<Image>(() =>
        {
            // or download it, load from a stream, resource, whatever...
            var result = Image.FromFile(imagePath);
            return result;
        });
    }
