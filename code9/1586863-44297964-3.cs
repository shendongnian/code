     public static void ImportFile(
                  [FileTrigger(@"fileupload\{name}", "*.*", WatcherChangeTypes.Created | WatcherChangeTypes.Changed)] Stream file,
                  FileSystemEventArgs fileTrigger,
                   [Blob("textblobs/{name}", FileAccess.Write)] Stream blobOutput,
                  TextWriter log)
            {
                log.WriteLine(string.Format("Processed input file '{0}'!", fileTrigger.Name));
               
                file.CopyTo(blobOutput);
               
                log.WriteLine("Upload File Complete");
              
            }
