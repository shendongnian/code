    Process process = new Process();
    process.StartInfo.RedirectStandardOutput = true;
    process.StartInfo.RedirectStandardError = true;
    process.StartInfo.FileName = "ffmpeg";
    process.StartInfo.Arguments = $"-i \"{originalFile}\" -ab 128 \"{outputPath}\"";
    process.StartInfo.UseShellExecute = false;
    process.StartInfo.CreateNoWindow = false;
    process.Start();
    process.WaitForExit(); 
