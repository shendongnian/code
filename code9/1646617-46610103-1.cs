    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 2)]
    class CustomWaveFormat : WaveFormat
    {
        public CustomWaveFormat(int rate, int bits, int channels) 
            : base(rate, bits, channels)
        {
            extraSize = 0;
        }
        public override void Serialize(BinaryWriter writer)
        {
            writer.Write((int)16); // wave format length
            writer.Write((short)Encoding);
            writer.Write((short)Channels);
            writer.Write((int)SampleRate);
            writer.Write((int)AverageBytesPerSecond);
            writer.Write((short)BlockAlign);
            writer.Write((short)BitsPerSample);
        }
    }
	
