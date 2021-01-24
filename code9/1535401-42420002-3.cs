        using (Stream output = File.OpenWrite("filename.csv"))
        using (Stream input = getResponse.Response.GetResponseStream())
        {
             byte[] buffer = new byte[8192];
             int bytesLength;
             while ((bytesLength = input.Read(buffer, 0, buffer.Length)) > 0)
             {
                  output.Write(buffer, 0, bytesLength);
             }
        }
