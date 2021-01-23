            try
            {
                while ((bytesRead = tempStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    //....
                    file.Write(buffer, 0, bytesRead);
                    totalBytesRead += bytesRead;
                }
            }
            catch
            {
                //Refresh the connection
            }
