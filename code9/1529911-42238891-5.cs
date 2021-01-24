    protected override void WriteFile(HttpResponseBase response)
    {
        // grab chunks of data and write to the output stream
        Stream outputStream = response.OutputStream;
        using (FileStream)
        {
            byte[] buffer = new byte[BufferSize];
            while (true)
            {
                int bytesRead = FileStream.Read(buffer, 0, BufferSize);
                if (bytesRead == 0)
                {
                    // no more data
                    break;
                }
                outputStream.Write(buffer, 0, bytesRead);
            }
        }
    }
