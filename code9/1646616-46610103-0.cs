    public virtual void Serialize(BinaryWriter writer)
    {
        writer.Write((int)(18 + extraSize)); // wave format length
        writer.Write((short)Encoding);
        writer.Write((short)Channels);
        writer.Write((int)SampleRate);
        writer.Write((int)AverageBytesPerSecond);
        writer.Write((short)BlockAlign);
        writer.Write((short)BitsPerSample);
        writer.Write((short)extraSize);
    }
