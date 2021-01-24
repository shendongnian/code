    static void Main(string[] args)
    {
        Process proc = new Process();
        proc.StartInfo.FileName = @"ffmpeg.exe";
        proc.StartInfo.Arguments = String.Format("-f rawvideo -vcodec rawvideo -s {0}x{1} -pix_fmt rgb24 -r {2} -i - -an -codec:v libx264 -preset veryfast -f mp4 -movflags frag_keyframe+empty_moov -",
            16, 9, 30);
        proc.StartInfo.UseShellExecute = false;
        proc.StartInfo.RedirectStandardInput = true;
        proc.StartInfo.RedirectStandardOutput = true;
        FileStream fs = new FileStream(@"out.mp4", FileMode.Create, FileAccess.Write);
        proc.Start();
        var readTask = _ConsumeOutputAsync(fs, proc.StandardOutput.BaseStream);
        //Generate frames and write to stdin
        for (int i = 0; i < 30 * 60 * 60; i++)
        {
            byte[] myArray = Enumerable.Repeat((byte)Math.Min(i, 255), 9 * 16 * 3).ToArray();
            proc.StandardInput.BaseStream.Write(myArray, 0, myArray.Length);
        }
        proc.StandardInput.BaseStream.Close();
        readTask.Wait();
        fs.Close();
        Console.WriteLine("Done!");
        Console.ReadKey();
    }
    private static async Task _ConsumeOutputAsync(FileStream fs, Stream baseStream)
    {
        int cb;
        byte[] rgb = new byte[4096];
        while ((cb = await baseStream.ReadAsync(rgb, 0, rgb.Length)) > 0)
        {
            fs.Write(rgb, 0, cb);
        }
    }
