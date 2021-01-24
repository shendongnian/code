    process =new Process();
    
    process.StartInfo.FileName = "ffmpeg";
    process.StartInfo.Arguments = "-i foo.VOB blabla.mp4";
    
    process.StartInfo.UseShellExecute = false;
    process.StartInfo.RedirectStandardOutput = true;
    
    process.Start();
