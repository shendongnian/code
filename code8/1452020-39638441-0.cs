    static void Main(string[] args)
    {
        VirusTotal virusTotal = new VirusTotal("INSERT API KEY HERE");
    
        //Use HTTPS instead of HTTP
        virusTotal.UseTLS = true;
    
        FileInfo fileInfo = new FileInfo("testfile.txt");
    
        //Create a new file
        File.WriteAllText(fileInfo.FullName, "This is a test file!");
    
         //Check if the file has been scanned before.
        Report fileReport = virusTotal.GetFileReport(fileInfo).First();
        bool hasFileBeenScannedBefore = fileReport.ResponseCode == 1;
    
        if (hasFileBeenScannedBefore)
        {
            Console.WriteLine(fileReport.ScanId);
        }
        else
        {
            ScanResult fileResults = virusTotal.ScanFile(fileInfo);
            Console.WriteLine(fileResults.VerboseMsg);
        }
    }
