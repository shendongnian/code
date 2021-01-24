    private void WriteFileInDownloadDirectly()
    {
        //Create a stream for the file
        Stream stream = null;
        //This controls how many bytes to read at a time and send to the client
        int bytesToRead = 10000;
        // Buffer to read bytes in chunk size specified above
        byte[] buffer = new byte[bytesToRead];
        // The number of bytes read
        try
        {
            //Create a WebRequest to get the file
            HttpWebRequest fileReq = (HttpWebRequest)HttpWebRequest.Create("Remote File URL");
            //Create a response for this request
            HttpWebResponse fileResp = (HttpWebResponse)fileReq.GetResponse();
            if (fileReq.ContentLength > 0)
                fileResp.ContentLength = fileReq.ContentLength;
            //Get the Stream returned from the response
            stream = fileResp.GetResponseStream();
            // prepare the response to the client. resp is the client Response
            var resp = HttpContext.Current.Response;
            //Indicate the type of data being sent
            resp.ContentType = "application/octet-stream";
            //Name the file 
            resp.AddHeader("Content-Disposition", $"attachment; filename=\"{ Path.GetFileName("Local File Path - can be fake") }\"");
            resp.AddHeader("Content-Length", fileResp.ContentLength.ToString());
            int length;
            do
            {
                // Verify that the client is connected.
                if (resp.IsClientConnected)
                {
                    // Read data into the buffer.
                    length = stream.Read(buffer, 0, bytesToRead);
                    // and write it out to the response's output stream
                    resp.OutputStream.Write(buffer, 0, length);
                    // Flush the data
                    resp.Flush();
                    //Clear the buffer
                    buffer = new byte[bytesToRead];
                }
                else
                {
                    // cancel the download if client has disconnected
                    length = -1;
                }
            } while (length > 0); //Repeat until no data is read
        }
        finally
        {
            if (stream != null)
            {
                //Close the input stream
                stream.Close();
            }
        }
    }
