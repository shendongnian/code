    private void Cut()
    {
      var filename = @"G:\Voice\Samples\LongAudioFile.wav";
      FileInfo fi = new FileInfo(filename);
      var outputPath = System.IO.Path.Combine(fi.Directory.FullName, string.Format("{0}_Shorter{1}", fi.Name.Replace(fi.Extension, ""), fi.Extension));
      TrimWavFile(filename, outputPath, TimeSpan.FromHours(1));
    }
    public static void TrimWavFile(string inPath, string outPath, TimeSpan duration)
    {
      using (WaveFileReader reader = new WaveFileReader(inPath))
      {
        using (WaveFileWriter writer = new WaveFileWriter(outPath, reader.WaveFormat))
        {
          float bytesPerMillisecond = reader.WaveFormat.AverageBytesPerSecond / 1000f;
          int startPos = 0;
          startPos = startPos - startPos % reader.WaveFormat.BlockAlign;
          int endBytes = (int)Math.Round(duration.TotalMilliseconds * bytesPerMillisecond);
          endBytes = endBytes - endBytes % reader.WaveFormat.BlockAlign;
          int endPos = endBytes;
          TrimWavFile(reader, writer, startPos, endBytes);
        }
      }
    }
    private static void TrimWavFile(WaveFileReader reader, WaveFileWriter writer, int startPos, int endPos)
    {
      reader.Position = startPos;
      byte[] buffer = new byte[reader.BlockAlign * 1024];
      while (reader.Position < endPos)
      {
        int bytesRequired = (int)(endPos - reader.Position);
        if (bytesRequired > 0)
        {
          int bytesToRead = Math.Min(bytesRequired, buffer.Length);
          int bytesRead = reader.Read(buffer, 0, bytesToRead);
          if (bytesRead > 0)
          {
            writer.Write(buffer, 0, bytesRead);
          }
        }
      }
    }
