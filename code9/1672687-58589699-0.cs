     public static byte[] GetZipFile(Dictionary<string, List<FileInformation>> allFileInformations)
        {
            MemoryStream compressedFileStream = new MemoryStream();
            //Create an archive and store the stream in memory.
            using (var zipArchive = new ZipArchive(compressedFileStream, ZipArchiveMode.Create, true))
            {
                foreach (var fInformation in allFileInformations)
                {
                    var files = allFileInformations.Where(x => x.Key == fInformation.Key).SelectMany(x => x.Value).ToList();
                    for (var i = 0; i < files.Count; i++)
                    {
                        ZipArchiveEntry zipEntry = zipArchive.CreateEntry(fInformation.Key + "/" + files[i].FileName);
                        var caseAttachmentModel = Encoding.UTF8.GetBytes(files[i].Content);
                        //Get the stream of the attachment
                        using (var originalFileStream = new MemoryStream(caseAttachmentModel))
                        using (var zipEntryStream = zipEntry.Open())
                        {
                            //Copy the attachment stream to the zip entry stream
                            originalFileStream.CopyTo(zipEntryStream);
                        }
                    }
                }
                //i added this line 
                zipArchive.Dispose();
                
                return compressedFileStream.ToArray();
            }
        }
    public void SaveZipFile(){
            var zipFileArray = Global.GetZipFile(allFileInformations);
            var zipFile = new MemoryStream(zipFileArray);
            FileStream fs = new FileStream(path + "\\111.zip", 
            FileMode.Create,FileAccess.Write);
            zipFile.CopyTo(fs);
            zipFile.Flush();
            fs.Close();
            zipFile.Close();
    }
