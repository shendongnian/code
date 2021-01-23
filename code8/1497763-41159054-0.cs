        if (FileUploader.HasFile)
        {
            try
            {
                        string filename = Path.GetFileName(FileUploader.FileName);
                        FileUploader.SaveAs(@"D:\Users\SGG90745\Desktop\PICTURES\" + filename);
                        Label1.Text = "Uploaded Successfully!!";
            }
            catch (Exception ex)
            {
                Label1.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
            }
        }
    }
