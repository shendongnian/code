    private static void PerformFadeOut(string inputPath, string outputPath, bool playNoSave = false)
    {
        WaveFileReader waveSource = new WaveFileReader(inputPath);
    
        ISampleProvider sampleSource = waveSource.ToSampleProvider();
    
        // Two seconds fade
        var fadeOut = new DelayFadeOutSampleProvider(sampleSource);
        fadeOut.BeginFadeOut(8000, 2000);
    
        if(playNoSave)
        {
            // Here the fade is played exactly where expected (@00:08)
            var player = new WaveOut();
            player.Init(fadeOut);
            player.Play();
        }
        else
        {
            // But when saving, the fade is applied @00:04!
            WaveFileWriter.CreateWaveFile(outputPath, new SampleToWaveProvider(fadeOut));
        }
    }
