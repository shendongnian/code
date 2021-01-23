        using(var writer = new BinaryWriter(System.IO.File.Open(path, FileMode.Create)))) {
    
           // do your read logic here and read into bytes
    
            var bytesLeft = bytes.Length;
            var bytesWritten = 0;
            while(bytesLeft > 0) {
                int chunk = Math.Min(64, bytesLeft);
                writer.WriteBytes(array, bytesWritten, chunk);
                bytesWritten += chunk;
                bytesLeft -= chunk;
                
                // calculate progress bar status
                backgroundWorker.ReportProgress(bytesWritten * 100 / array.Length);
            }
        }
