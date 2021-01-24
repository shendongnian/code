        private String UploadToFtp(String destinyPath, String sourcePath, ref FtpClient client)
        {
            String error = "success";
            try
            {
                // Stream im Arbeitsspeicher erstellen
                using (Stream memoryStream = new MemoryStream())
                {
                    // Ziparchive anhand des verweißes auf den memoryStream erstellen
                    using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                    {
                        // Dateien im gezippten Ordner bestimmen
                        foreach (string path in Directory.EnumerateFiles(sourcePath))
                        {
                            ZipArchiveEntry entry;
                            if (path.Length > 248)
                            {
                                // Bestimmte Dateien ins Ziparchive erstellen mit langen Pfad
                                entry = archive.CreateEntry(ZlpPathHelper.GetFileNameFromFilePath(path));
                            }
                            else
                            {
                                // Bestimmte Dateien ins Ziparchive erstellen mit kurzem Pfad
                                entry = archive.CreateEntry(Path.GetFileName(path));
                            }
                            // Original Daten (entryStream) in Ziparchivedateien (fileStream) schreiben
                            using (Stream entryStream = entry.Open())
                            {
                                using (Stream fileStream = Delimon.Win32.IO.File.OpenRead(path))
                                {
                                    fileStream.CopyTo(entryStream);
                                }
                            }
                        }
                    }
                    //memoryStream curser auf anfang setzen
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    //Stream auf den FtpServer laden
                    client.RetryAttempts = 3;
                    client.Upload(memoryStream, destinyPath);
                }
            }
            catch (Exception ex)
            {
                error = ex.ToString();
            }
            return error;
        }
