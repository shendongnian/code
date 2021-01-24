    string sourceFile;
    string newFile = "C:\NewFile\NewFile.txt";
    string fileToRead = "C:\ReadFile\ReadFile.txt";
    bool overwriteExistingFile = true; //change to false if you want no to overwrite the existing file.
    
    bool isReadSuccess = getDataFromFile(fileToRead, ref sourceFile); 
    
    if (isReadSuccess)
    {
        File.Copy(sourceFile, newFile, overwriteExistingFile);
    }
    else
    {
        Console.WriteLine("An error occured :" + sourceFile);
    }
    
    
    
    //Reader Method you can use this or modify it depending on your needs.
    public static bool getDataFromFile(string FileToRead, ref string readMessage)
    {
        try
        {
            readMessage = "";
            if (!File.Exists(FileToRead))
            {
                readMessage = "File not found: " + FileToRead;
                return false;
            }
            using (StreamReader r = new StreamReader(FileToRead))
            {
                readMessage = r.ReadToEnd();
            }
            return true;
        }
        catch (Exception ex)
        {
            readMessage = ex.Message;
            return false;
        }
    }
