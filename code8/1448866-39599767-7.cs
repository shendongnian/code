    private string baseAppPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                        "Company Name", "Product Name", "Temp Files");
   ...
    byte[] dataBytes = null;
    string ext;
    string tempFile = Path.Combine(appPath, 
        Path.GetFileNameWithoutExtension(Path.GetTempFileName())); 
    ... (access db)
       if (rdr.Read())
        {
            ext = rdr.GetString("itemType");
            dataBytes = (byte[])rdr["imgData"];
            tempFile += ext;
            File.WriteAllBytes(tempFile , dataBytes);
        }
        Process prc = new Process();
        prc.StartInfo.FileName = tempFile;
        prc.Start();
