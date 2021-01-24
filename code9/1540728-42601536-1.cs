    using (SpeechSynthesizer synthesizer = new SpeechSynthesizer())
    {
        synthesizer.SetOutputToDefaultAudioDevice();
        
        // this
        synthesizer.SelectVoice("ScanSoft Virginie_Dri40_16kHz");
        // or this
        synthesizer.SelectVoiceByHints(VoiceGender.Neutral, VoiceAge.NotSet, 0, CultureInfo.GetCultureInfo("fr-fr"));
        synthesizer.Speak("Bonjour !");
    }
