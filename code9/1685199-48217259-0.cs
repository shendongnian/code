    /// <summary>
    /// Opens a MIDI file stream for reading
    /// </summary>
    /// <param name="inputStream">The input stream containing a MIDI file</param>
    /// <param name="strictChecking">If true will error on non-paired note events</param>
    public MidiFile(Stream inputStream, bool strictChecking) :
        this(inputStream, strictChecking, false)
    {
    }
