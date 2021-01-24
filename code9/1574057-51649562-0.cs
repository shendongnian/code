    public static void DownloadLargeFile(string DownloadFileName, string FilePath, string ContentType, HttpResponse response)
        {
            Stream stream = null;
            // read buffer in 1 MB chunks
            // change this if you want a different buffer size
            int bufferSize = 1048576;
                        
            byte[] buffer = new Byte[bufferSize];
            // buffer read length
            int length;
            // Total length of file
            long lengthToRead;
            try
            {
                // Open the file in read only mode 
                stream = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                // Total length of file
                lengthToRead = stream.Length;
                response.ContentType = ContentType;
                response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(DownloadFileName, System.Text.Encoding.UTF8));
                while (lengthToRead > 0)
                {
                    // Verify that the client is connected.
                    if (response.IsClientConnected)
                    {
                        // Read the data in buffer
                        length = stream.Read(buffer, 0, bufferSize);
                        // Write the data to output stream.
                        response.OutputStream.Write(buffer, 0, length);
                        // Flush the data 
                        response.Flush();
                        //buffer = new Byte[10000];
                        lengthToRead = lengthToRead - length;
                    }
                    else
                    {
                        // if user disconnects stop the loop
                        lengthToRead = -1;
                    }
                }
            }
            catch (Exception exp)
            {
                // handle exception
                response.ContentType = "text/html";
                response.Write("Error : " + exp.Message);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
                response.End();
                response.Close();
            }
        }
