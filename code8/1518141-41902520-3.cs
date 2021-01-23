    catch (IOException ex)
    {
        if (ex.Message.Contains("The process cannot access the file") && 
            ex.Message.Contains("because it is being used by another process") )
        {
            MessageBox.Show("Copying files...");
            FileSystem.CopyDirectory(sourcePath, newDir);
            MessageBox.Show("Completed!");
        }
        else
        {
            string err = "Issue when performing file copy: " + ex.Message;
            MessageBox.Show(err);
        }
    }
