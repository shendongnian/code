        byte[] byteContent = response.Content.ReadAsByteArrayAsync().Result;
        string filename = @"C:\temp\1111.zip";
        File.WriteAllBytes(filename, byteContent);
        string destinationDir = @"c:\temp";
        string xmlFilename = "report.xml";
        System.IO.Compression.ZipFile.ExtractToDirectory(filename, destinationDir);
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(Path.Combine(destinationDir, xmlFilename));
        //xml reading goes here...
