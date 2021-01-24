    string input = "E:\\ii.mp4";
    string output = "E:\\oo.mp4";
    Process proc = new Process();
    proc.StartInfo.FileName = @"E:\\DuyProject\\Format_H264_H265\\ffmpeg\\ffmpeg.exe";
    proc.StartInfo.Arguments = "-i " + input + " -c:v libx265 " + output;
    proc.StartInfo.RedirectStandardError = true;
    proc.StartInfo.UseShellExecute = false;
    if (!proc.Start())
    {
        Console.WriteLine("Error starting");
        return;
    }
    StreamReader reader = proc.StandardError;
    string line;
    while ((line = reader.ReadLine()) != null)
    {
       Console.WriteLine(line);
    }
    proc.Close();
