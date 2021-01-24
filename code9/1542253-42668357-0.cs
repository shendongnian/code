    public static void Trimmer(string localStoragePath, CloudBlockBlob outPutBlob)
    {
        string path2 = localStoragePath.Remove(localStoragePath.Length - 4) + "_trimmed.mp4";
        string ffmpeg = "ffmpeg.exe";
        bool success = false;
        string ExeArguments;
        try
        {
            Process proc;
            proc = new Process();
            proc.StartInfo.FileName = ffmpeg;
            ExeArguments = @" -t 10 -i " + localStoragePath + " -map_metadata 0 -acodec copy "
                                            + path2 + " -y";
            Trace.TraceInformation(ExeArguments);
            proc.StartInfo.Arguments = ExeArguments;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.ErrorDialog = false;
            proc.Start();
            proc.WaitForExit();
        }
        catch(Exception ex)
        {
            Trace.TraceError($"Trimmer exception:{ex.Message}\r\nStackTrace:{ex.StackTrace}");
        }
        var fi = new FileInfo(path2);
        if (fi.Exists)
        {
            success = true;
            Trace.TraceInformation(string.Format("Video has been trimmed"));
            using (Stream file = File.OpenRead(path2))
            {
                Trace.TraceInformation(string.Format("Video moving to CopyStream"));
                Trace.TraceInformation(string.Format("Video has been trimmed and now sent to be copied to stream"));
                byte[] buffer = new byte[8 * 1024];
                int len;
                using (Stream outpuStream = outPutBlob.OpenWrite())
                {
                    while ((len = file.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        outpuStream.Write(buffer, 0, len);
                    }
                }    
            }
        }
        else
        {
            Trace.TraceWarning(string.Format("Video has not been trimmed"));
        }
    }
