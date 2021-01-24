    using System.IO;
    using System.IO.Compression;
    using System.Text;
    private void Zip (byte[] imageBytes) {
    
     string fileName = baseFilePath + "sample.zip";
     using (FileStream f2 = new FileStream(fileName, FileMode.Create)){
            using (GZipStream gz = new GZipStream(f2, CompressionMode.Compress, false))
            {
                gz.Write(imageBytes, 0, imageBytes.Length);
            }
       }
    }
