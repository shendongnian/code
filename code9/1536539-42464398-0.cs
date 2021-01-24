    var request = MyService.Files.Get(FileID);
    var stream = new System.IO.MemoryStream();
    try
    {
        request.Download(stream);
        System.IO.FileStream file = new System.IO.FileStream(PathToSave, System.IO.FileMode.Create, System.IO.FileAccess.Write);
        Stream.WriteTo(file);
        file.Close();
    }
    catch (Exception ex)
    {
         MessageBox.Show(ex.Message, "Error Occured:", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
