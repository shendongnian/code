    public new static byte[] GetSound(Order o)
    {
        const SpeechVoiceSpeakFlags speechFlags = SpeechVoiceSpeakFlags.SVSFlagsAsync;
        var synth = new SpVoice();
        var wave = new SpMemoryStream();
        var voices = synth.GetVoices();
        try
        {
            // synth setup
            synth.Volume = Math.Max(1, Math.Min(100, o.Volume ?? 100));
            synth.Rate = Math.Max(-10, Math.Min(10, o.Rate ?? 0));
            foreach (SpObjectToken voice in voices)
            {
                if (voice.GetAttribute("Name") == o.Voice.Name)
                {
                    synth.Voice = voice;
                }
            }
            wave.Format.Type = SpeechAudioFormatType.SAFT22kHz16BitMono;
            synth.AudioOutputStream = wave;
            synth.Speak(o.Text, speechFlags);
            synth.WaitUntilDone(Timeout.Infinite);
            var waveFormat = new WaveFormat(22050, 16, 1);
            using (var ms = new MemoryStream((byte[])wave.GetData()))
            using (var reader = new RawSourceWaveStream(ms, waveFormat))
            using (var outStream = new MemoryStream())
            using (var writer = new WaveFileWriter(outStream, waveFormat))
            {
                reader.CopyTo(writer);
                return o.Mp3 ? ConvertToMp3(outStream) : outStream.GetBuffer();
            }
        }
        finally
        {
            Marshal.ReleaseComObject(voices);
            Marshal.ReleaseComObject(wave);
            Marshal.ReleaseComObject(synth);
        }
    }
