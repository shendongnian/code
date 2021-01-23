    bool exception = false;
    
                try
                {
    
                    using (WebClient client = new WebClient())
                    {
                        client.Credentials = new NetworkCredential(FtpUser.Text, FtpPass.Text);
                        client.UploadFile("ftp://example.com/file.txt", "STOR", MyFilePath);
                       
                    }
    
                }
                catch (Exception ex)
                {
                    exception = true;
                    MessageBox.Show(ex.Message);
                }
    
    
                if(!exception){
                    MessageBox.Show("Upload worked!");
                }
