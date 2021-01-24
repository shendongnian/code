    static void Main(string[] args)
    {
        // test path... replace with the path you need
        string baseFolder = @"D:\test\";
        string imgName = textBoxEmplNo.Text + ".jpg";
        bool fileFound = false;
        DirectoryInfo di = new DirectoryInfo(baseFolder);
        foreach (var file in di.GetFiles(imgName, SearchOption.AllDirectories))
        {
            pictureBox1.Visible = true;
            pictureBox1.Image = Image.FromFile(file.FullName);
            fileFound = true;
            break;
        }
        if (!fileFound)
        {
            pictureBox1.Visible = true;
            pictureBox1.Image = Image.FromFile(@"C:\Users\jun\Desktop\images\photo\No-image-found.jpg");
        }
    }
