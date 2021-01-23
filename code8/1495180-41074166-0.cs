    string text = string.Empty;
    using (FileStream zipToOpen = new FileStream(@"c:\test\release.zip", FileMode.Open)) {
        using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Read)) {
            ZipArchiveEntry readmeEntry = archive.GetEntry("Readme.txt");
            using (StreamReader reader = new StreamReader(readmeEntry.Open())) {
                text = reader.ReadToEnd();
            }
        }
    }
    Console.WriteLine("Contents of WriteText.txt = {0}", text);
    
