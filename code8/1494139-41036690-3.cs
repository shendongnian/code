    public void writetoFile(HttpWebResponse response)
    {
        var inStream = response.GetResponseStream();
        using (var file = System.IO.File.OpenWrite("your file path here"))
        {
            inStream.CopyTo(file);
        }
    }
