                using (ZipFile zip = ZipFile.Read(modPath))
                {
                    ZipEntry e;
                    foreach (ZipEntry k in zip)
                    {
                        if (k.FileName.Contains("info.json"))
                        {
                            e = k;
                            break;
                        }
                    }
                }
