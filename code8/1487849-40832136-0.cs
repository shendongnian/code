                string zipPath = @""+ System.IO.Directory.GetCurrentDirectory() + "/Temp/"+ currentupdate+".zip";
                string extractPath = @""+ System.IO.Directory.GetCurrentDirectory() + "/Temp";
                using (ZipArchive archive = ZipFile.OpenRead(zipPath))
                {
                        foreach (ZipArchiveEntry entry in archive.Entries)
                        {
                        string fullPath = Path.Combine(extractPath, entry.FullName);
                        if (String.IsNullOrEmpty(entry.Name))
                        {
                            Directory.CreateDirectory(fullPath);
                        }
                        else
                        {
                           entry.ExtractToFile(fullPath,true);
                        }
                    }
                }
