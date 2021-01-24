    //BaseFolder that contains the multiple folders 
    string baseFolder = "C:\\Users\\myName\\Desktop\\folderContainingFolders";
    string[] employeeFolders = Directory.GetDirectories( baseFolder );
    //Hardcoded employeeNr for test and png because I had one laying around
    string imgName =  "1.png";
    //Bool to see if file is found after checking all
    bool fileFound = false;
    foreach ( var folderName in employeeFolders )
    {
        var path = Path.Combine(folderName, imgName);
        if (File.Exists(path))
        {
            pictureBox1.Visible = true;
            pictureBox1.Image = Image.FromFile(path);
            fileFound = true;
            //If you want to stop looking, break; here 
        }
    }
    if(!fileFound)
    {
        //Display message that No such image found
        pictureBox1.Visible = true;
        pictureBox1.Image = Image.FromFile(@"C:\Users\may\Documents\Visual Studio 2013\WebSites\EV\photo\No-image-found.jpg");
    }
