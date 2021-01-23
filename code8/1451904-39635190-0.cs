    public async static Task ChangeToSpeech(string text, MediaElement media)
    {
        var synth = new SpeechSynthesizer();
        var voices = SpeechSynthesizer.AllVoices;
        synth.Voice = voices.First(x => x.Gender == VoiceGender.Female);
        SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync(text);
        var tcs = new TaskCompletionSource<int>();
        RoutedEventHandler handler = delegate { tcs.TrySetResult(10); };
        media.MediaEnded += handler;
        try
        {
            media.SetSource(stream, stream.ContentType);
            media.Play();
            // Asynchronously wait for the event to fire
            await tcs.Task;
        }
        finally
        {
            media.MediaEnded -= handler;
        }
    }
