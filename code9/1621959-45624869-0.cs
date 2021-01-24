    //OctoBox: Picturebox
    //Octocat: Octocat.png image
    //Tested with:
    //Build action: Embeded Resource
    // 1st:
    OctoBox.Image = (Bitmap)Resources.ResourceManager.GetObject("Octocat");
    //2nd
    Assembly asm = Assembly.GetExecutingAssembly();
    Stream octoStream = asm.GetManifestResourceStream($"{asm.GetName().Name}.Resources.Octocat.png");
    if (octoStream != null)
    {
        OctoBox.Image = Image.FromStream(octoStream);
        octoStream.Close();
    }
    //Tested with:
    //Build action: None, Content and embeded resource
    OctoBox.Image = Resources.Octocat;
