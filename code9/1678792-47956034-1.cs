    internal static byte[] ConvertToMp3(Stream wave)
    {
        wave.Position = 0;
        using (var mp3 = new MemoryStream())
        using (var reader = new WaveFileReader(wave))
        using (var writer = new LameMP3FileWriter(mp3, reader.WaveFormat, 128))
        {
            reader.CopyTo(writer);
            mp3.Position = 0;
            return mp3.ToArray();
        }
    }
