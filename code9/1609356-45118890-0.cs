    public static void Compress(DirectoryInfo directorySelected)
            {
                foreach (FileInfo fileToCompress in directorySelected.GetFiles())
                {
                    using (FileStream originalFileStream = fileToCompress.OpenRead())
                    {
                        if ((File.GetAttributes(fileToCompress.FullName) & 
                           FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz")
                        {
                            using (FileStream compressedFileStream = File.Create(fileToCompress.FullName + ".gz"))
                            {
                                using (GZipStream compressionStream = new GZipStream(compressedFileStream, 
                                   CompressionMode.Compress))
                                {
                                    originalFileStream.CopyTo(compressionStream);
    
                                }
                            }
                            FileInfo info = new FileInfo(directoryPath + "\\" + fileToCompress.Name + ".gz");
                            Console.WriteLine("Compressed {0} from {1} to {2} bytes.",
                            fileToCompress.Name, fileToCompress.Length.ToString(), info.Length.ToString());
                        }
    
                    }
                }
            }
