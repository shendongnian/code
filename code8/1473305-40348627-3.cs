    public async Task<string> GetFilePathAsync(TestModel model)
        {
            string filePath = string.Empty;
            var response = await cgRequestHelper.DownloadAsync(model);  
    
            if (response.IsSuccessStatusCode)
            {                   
                Stream cgStream = await response.Content.ReadAsStreamAsync();
                filePath = SaveCgStream(cgStream , model.FileName);
            }
            return filePath;
        }
    
        public string SaveCgStream(Stream cgStream, string fileName)
            {
                if (response == null)
                    throw new ArgumentNullException("response");
                if (string.IsNullOrEmpty(fileName))
                    throw new ArgumentNullException("fileName");
    
                const int CHUNK_SIZE = 40000;
                var filePath = _CreateTemporaryLocation(fileName);
                var fileStream = File.Create(filePath, CHUNK_SIZE);
    
                int bytesRead;
                var buffer = new byte[CHUNK_SIZE];
                bool isReadStarted = false;
                try
                {
                    do
                    {
                        bytesRead = cgStream.Read(buffer, 0, CHUNK_SIZE);
                        if (bytesRead > 0)
                        {
                            isReadStarted = true;
                            fileStream.Write(buffer, 0, bytesRead);
                        }
                    } while (bytesRead > 0);
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    fileStream.Close();
                }
                return filePath;
            }
