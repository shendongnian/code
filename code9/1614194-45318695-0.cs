    currentDir = fb.SelectedPath; // Get the selected folder by the user;
    textBoxD.Text = currentDir;
    var dirInfo = new DirectoryInfo(currentDir);
    var files = dirInfo.GetFiles().Where(c=>c.Extension.Equals(".jpg") || c.Extension.Equals(".jpeg") || c.Extension.Equals(".bmp") || c.Extension.Equals(".png"));
    
    var listBoxImages = new ListBox(); //I think listBoxImages is of type ListBox control
    foreach (var image in files)
    {   
        //Add Images/Files to the list box
        listBoxImages.Items.Add(image.Name);
    }
