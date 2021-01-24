        private const int fileLengthPerMB = 1048576;
        private const int permitedFileSize = 10;
        int postedFileLength = fuHolterDiary.PostedFile.ContentLength;
        if ((postedFileLength / fileLengthPerMB) <= permitedFileSize)
        {
          e.IsValid = true;
        }
        else
        {
          e.IsValid = false;
          lblError.Text = "File size is too large. Maximum size permitted is 10 MB.";                           
        }
