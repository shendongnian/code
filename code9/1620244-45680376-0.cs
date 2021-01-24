    /// <summary>
    /// Creates a new MixingSampleProvider, with no inputs, but a specified WaveFormat
    /// </summary>
    /// <param name="waveFormat">The WaveFormat of this mixer. All inputs must be in this format</param>
    public MixingSampleProvider( WaveFormat waveFormat )
    {
        if( waveFormat.Encoding == WaveFormatEncoding.Extensible )
        {
            if( ( ( WaveFormatExtensible )waveFormat ).SubFormat != NAudio.Dmo.AudioMediaSubtypes.MEDIASUBTYPE_IEEE_FLOAT )
            {
                throw new ArgumentException( "Must be already floating point" );
            }
        }
        else if( waveFormat.Encoding != WaveFormatEncoding.IeeeFloat )
        {
            throw new ArgumentException( "Mixer wave format must be IEEE float" );
        }
        sources = new List<ISampleProvider>( );
        WaveFormat = waveFormat;
    }
