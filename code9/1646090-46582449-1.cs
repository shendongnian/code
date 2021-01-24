    foreach (var voice in AVSpeechSynthesisVoice.GetSpeechVoices())
    {
        Console.WriteLine(voice.Language); // review all the languages available
    }
    var speechSynthesizer = new AVSpeechSynthesizer();
    var speechUtterance = new AVSpeechUtterance("jak się masz?")
    {
        Voice = AVSpeechSynthesisVoice.FromLanguage("pl-PL"),
        Volume = 1.0f,
        PitchMultiplier = 1.0f
    };
