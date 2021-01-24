    private List<string> UnzipFiles()
    {
        Chilkat.Zip zip = new Chilkat.Zip();
        string zippedFilePath = @"C:\Users\TestData";
        string unzippedFilePath = @"C:\Users\Temp";
        var unzippedFileList = new List<string>();
        bool success = zip.UnlockComponent("LIVECOZIP_3BzssvnbmYxp");
        if (!success)
        {
            string errorMsg = zip.LastErrorText;
            Console.WriteLine(errorMsg);
            return errorMsg;
        }
        string[] newzip = (Directory.GetFiles(zippedFilePath));
        foreach (string file in newzip)
        {
            unzippedFileList.Add(file);
            success = zip.OpenZip(file);
            {
                Console.WriteLine(zip.LastErrorText);
            }
            zip.DecryptPassword = "hANhvU8MX7iq0f2M";
            int unzipCount;
            unzipCount = zip.Unzip(unzippedFilePath);
            if (unzipCount < 0)
            {
                Console.WriteLine("unzipping file");
            }
        }
        return unzippedFileList;
    }
