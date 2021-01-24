    using (var stream = new MemoryStream()) {
        using (var sw = new StreamWriter(stream)) {
            foreach (var record in lst) {
                sw.WriteLine(record.surname + "," + record.name);
            }
            sw.Flush();
            stream.Position = 0;
            using (ZipFile zipFile = new ZipFile()) {
                zipFile.AddEntry("Records.txt", stream);
                zipFile.Save("archive.zip");
            }
        }
    }
