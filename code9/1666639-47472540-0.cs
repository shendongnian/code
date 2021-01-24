            string strDirectoryPath = @"C:\Users\UserDesktopName\Desktop\";
            WebClient User = new WebClient();
            foreach (string strFilePath in Directory.GetFiles(strDirectoryPath))
            {
                string strFileExtension = Path.GetExtension(strFilePath);
                if (strFileExtension == ".pdf")
                {
                    Byte[] FileBuffer = User.DownloadData(strFilePath);
                    this.Response.ContentType = "application/pdf";
                    this.Response.AppendHeader("Content-Disposition;", "attachment;filename=" + FileBuffer);
                    this.Response.WriteFile(strFilePath);
                    this.Response.End();
                }
            }
