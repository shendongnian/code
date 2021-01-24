     public static void ProcessQueueMessage(
            [QueueTrigger("blobcopyqueue")] string filename, TextWriter log,
             [Blob("textblobs/{queueTrigger}", FileAccess.Write)] Stream blobOutput
            )
            {
                //set the input file path
                string inputfile = string.Format(@"D:\home\site\wwwroot\video\{0}", filename);
                //set the input file path
                string outputFile = string.Format(@"D:\home\site\wwwroot\video-compress\{0}", filename);
     
                using (var engine = new Engine(@"D:\home\site\wwwroot\compress\ffmpeg.exe"))
                {
    
                    string command = string.Format(@"-i {0} -vcodec h264 -b:v 250k -acodec mp2  {1}", inputfile, outputFile);
    
                    //you could change the command value as what you want to use
                    engine.CustomCommand(command);
                }
    
                using (var fileStream = System.IO.File.OpenRead(outputFile))
                {
                    fileStream.CopyTo(blobOutput);
                }
    
                //after compress delete the file.
                //File.Delete(inputfile);
                // File.Delete(outputFile);
    
            }
