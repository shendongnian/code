          void ReadFiles()
          {
            try
            {
                DateTime lastScanDate = DateTime.Now;
                foreach (string filePath in System.IO.Directory.GetFiles(@"C:\Users\cozogul\Desktop\test"))
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(filePath);
                    if (fi.CreationTime >= lastScanDate)
                    {
                        //read file
                    }
                    else
                    {
                        //Don't read file.
                    }
                }
            }
            catch (Exception ex)
            {
                //Log your error
            }
        }
