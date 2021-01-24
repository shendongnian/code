    public static void StereoToMono(string sourceFile, string outputFile)
        {
            using (var waveFileReader = new WaveFileReader(sourceFile))
            {
                var outFormat = new WaveFormat(waveFileReader.WaveFormat.SampleRate, 1);
                using (var resampler = new MediaFoundationResampler(waveFileReader, outFormat))
                {
                    WaveFileWriter.CreateWaveFile(outputFile, resampler);
                }
            }
        }
