    public static void SendFile(HttpListenerResponse oResp, string filePath, long startPoint)
    {
        using (FileStream fs = File.OpenRead(filePath))
        {
            fs.Seek(startPoint, SeekOrigin.Begin);
            fs.CopyTo(oResp.OutputStream);
            //Added: close the response
            oResp.Close();
        }
    }
