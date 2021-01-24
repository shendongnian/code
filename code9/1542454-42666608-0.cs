     bool isValidFile = false;
           
                string[] validFileTypes = { "xlsx", "xls", "pdf" };
                string ext = Path.GetExtension(File_Uploader.PostedFile.FileName);
             
                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (ext == "." + validFileTypes[i])
                    {
                        isValidFile = true;
                        break;
                    }
                }
