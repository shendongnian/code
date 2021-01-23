        try
        {
            {
                #region fileupload
                string fn = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                string ret = Rename.ChangeName();
                string SaveLocation = Server.MapPath("Upload") + "\\" + ret;
                try
                {
                    FileUpload1.PostedFile.SaveAs(SaveLocation);
                }
                catch (Exception ex)
                {
                    if (ex is ArgumentNullException || ex is NullReferenceException)
					{
						throw ex; 
					}
                }
                string PicAddress = "~/Upload/" + ret;
                #endregion
