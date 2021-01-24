    void downloadFile(int fileNr)
    {
        FileStream writer;
        //...
 
        if (form1.checkBox1.Text == "Download satellite images")
        {
            writer = LocalDirectorySettings(file);
        }
        else
        {
            writer = new FileStream(this.LocalDirectory + "\\" + file.Name, System.IO.FileMode.Create);
        }
        //...
    }
    public FileStream LocalDirectorySettings(FileInfo file)
    {
        try
        {
            //...
            string fileName = this.LocalDirectory + "\\" + "test.png"; //file.Name + "---" + countFilesNames++.ToString("D6") + ".png";
            return new FileStream(fileName, System.IO.FileMode.Create);
        }
        catch (Exception err)
        {
            string ggg = err.ToString();
            throw; // you don't actually handle the exception, so rethrowing
                   // is the appropriate action here. Your only alternative
                   // would be to return "null" and have the caller check for
                   // that return value explicitly.
        }
    }
