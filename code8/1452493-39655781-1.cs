    AudioPlayer.AddSamples(package);
    internal class AudioPlayer
    {
        private static readonly BufferedWaveProvider WaveProvider = new BufferedWaveProvider(new WaveFormat());
        private static DirectSoundOut _waveOut;
        public static void AddSamples(byte[] buffer)
        {
            WaveProvider.AddSamples(buffer, 0, buffer.Length);
        }
        public static void Run()
        {
            _waveOut = new DirectSoundOut();
            _waveOut.Init(WaveProvider);
            _waveOut.Play();
        }
    }
