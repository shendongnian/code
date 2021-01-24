    Task<FileContentResult> task = Task.Run(() =>
    {
        using (SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer())
        {
            using (MemoryStream stream = new MemoryStream())
            {
                speechSynthesizer.SetOutputToWaveStream(stream);
                speechSynthesizer.Speak(text);
                var bytes = stream.GetBuffer();
                return File(bytes, "audio/x-wav");
            }
        }
    });
