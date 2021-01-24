     public static void FindFiles (string path)
            {
                foreach(string fileName in Directory.GetFiles(path))
                {
    
                    if (Path.GetExtension(fileName) == ".zip")
                    {
                        Console.WriteLine(fileName);
    
                        ExtractZipFile(fileName, null, Path.GetDirectoryName(fileName) + @"\" + Path.GetFileNameWithoutExtension(fileName));
                        File.Delete(fileName);
                    }
                    else if(Path.GetExtension(fileName)==".gz" && Path.GetFileNameWithoutExtension(fileName).Contains("tar"))
                    {
                        Console.WriteLine(fileName);
    
                        ExtractTGZ(fileName, Path.GetDirectoryName(fileName) + @"\" + Path.GetFileNameWithoutExtension(fileName));
                        File.Delete(fileName);
    
                    }
                    else if(Path.GetExtension(fileName)==".tar")
                    {
                        Console.WriteLine(fileName);
                        ExtractTar(fileName, Path.GetDirectoryName(fileName) + @"\" + Path.GetFileNameWithoutExtension(fileName));
                        File.Delete(fileName);
                    }
                    else if (Path.GetExtension(fileName) == ".gz" && !(Path.GetFileNameWithoutExtension(fileName).Contains("tar")))
                    {
                        Console.WriteLine(fileName);
                        ExtractGZip(fileName, Path.GetDirectoryName(fileName) + @"\" + Path.GetFileNameWithoutExtension(fileName));
                        File.Delete(fileName);
                    }
    
                    //Console.WriteLine(fileName);
    
                }
    
                foreach (string directory in Directory.GetDirectories(path))
                {
                    FindFiles(directory);
                }
    
            }
    
            public static void ExtractZipFile(string archiveFilenameIn, string password, string outFolder)
            {
                ZipFile zf = null;
                try
                {
                    FileStream fs = File.OpenRead(archiveFilenameIn);
                    zf = new ZipFile(fs);
                    if (!String.IsNullOrEmpty(password))
                    {
                        zf.Password = password;		// AES encrypted entries are handled automatically
                    }
                    foreach (ZipEntry zipEntry in zf)
                    {
                        if (!zipEntry.IsFile)
                        {
                            continue;			// Ignore directories
                        }
                        String entryFileName = zipEntry.Name;
                        
                        byte[] buffer = new byte[4096];		// 4K is optimum
                        Stream zipStream = zf.GetInputStream(zipEntry);
    
                        
                        String fullZipToPath = Path.Combine(outFolder, entryFileName);
                        string directoryName = Path.GetDirectoryName(fullZipToPath);
                        if (directoryName.Length > 0)
                            Directory.CreateDirectory(directoryName);
                       
                        using (FileStream streamWriter = File.Create(fullZipToPath))
                        {
                            StreamUtils.Copy(zipStream, streamWriter, buffer);
                        }
    
                       
                    }
                }
                finally
                {
                    if (zf != null)
                    {
                        zf.IsStreamOwner = true; // Makes close also shut the underlying stream
                        zf.Close(); // Ensure we release resources
                    }
                }
            }
    
            public static void ExtractTGZ(String gzArchiveName, String destFolder)
            {
    
                Stream inStream = File.OpenRead(gzArchiveName);
                Stream gzipStream = new GZipInputStream(inStream);
    
                TarArchive tarArchive = TarArchive.CreateInputTarArchive(gzipStream);
                tarArchive.ExtractContents(destFolder);
                tarArchive.Close();
    
                gzipStream.Close();
                inStream.Close();
            }
    
            public static void ExtractTar(String tarFileName, String destFolder)
            {
    
                Stream inStream = File.OpenRead(tarFileName);
    
                TarArchive tarArchive = TarArchive.CreateInputTarArchive(inStream);
                tarArchive.ExtractContents(destFolder);
                tarArchive.Close();
    
                inStream.Close();
            }
    
            public static void ExtractGZip(string gzipFileName, string targetDir)
            {
    
            
                using (FileStream fInStream = new FileStream(gzipFileName, FileMode.Open, FileAccess.Read))
                {
                    using (GZipStream zipStream = new GZipStream(fInStream, CompressionMode.Decompress))
                    {
                        
                        using (FileStream fOutStream = new FileStream(targetDir, FileMode.Create, FileAccess.ReadWrite))
                        {
                            byte[] tempBytes = new byte[4096];
                            int i;
                            while ((i = zipStream.Read(tempBytes, 0, tempBytes.Length)) != 0)
                            {
                                fOutStream.Write(tempBytes, 0, i);
                            }
                        }
                    }
                }
            }
