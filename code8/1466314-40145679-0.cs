    using (ZipArchive archive = new ZipArchive(webResponse.GetResponseStream()))
                    {
                        foreach (ZipArchiveEntry entry in archive.Entries)
                        {
                            Stream s = entry.Open();
                            var sr = new StreamReader(s);
                            var myStr = sr.ReadToEnd();
                        }
                    }
