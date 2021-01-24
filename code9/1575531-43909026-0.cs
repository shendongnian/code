    //Hardcoded employeeNr for test and png because I had one laying around
    string baseFolder = "C:\\Users\\myName\\Desktop\\folderContainingFolders";
    string[] employeeFolders = { "folderNameA", "folderNameB", "folderNameC" };
    string imgName =  "1.png";
    bool fileFound = false;
    foreach ( var folderName in employeeFolders )
    {
        var path = Path.Combine( baseFolder, folderName, imgName );
        if (File.Exists(path))
        {
            pictureBox1.Visible = true;
            pictureBox1.Image = Image.FromFile(path);
            fileFound = true;
        }
    }
    if(!fileFound)
    {
        //Display message that No such image found
        pictureBox1.Visible = true;
        pictureBox1.Image = Image.FromFile(@"C:\Users\may\Documents\Visual Studio 2013\WebSites\EV\photo\No-image-found.jpg");
    }
