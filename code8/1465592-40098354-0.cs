    public Form2()
    {
        InitializeComponent();
        string path = string.empty;
        string labelPath = string.empty;
        string objectPath = string.empty;
        setPaths(ref path, ref labelPath, ref objectPath);
        current = this;
        instantiateNumUpDown();
        System.IO.File.WriteAllText(labelPath, " ");
    }
    public static void setPaths(ref string path, ref string labelPath, ref string objectPath)
    {
        var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        path = Path.Combine(systemPath, "TextDynamic.txt");
        labelPath = Path.Combine(systemPath, "currentLabel.txt");
        objectPath = Path.Combine(systemPath, "object.txt");
    }
