    [HttpPost]
    public async Task<ActionResult> TTS(string text)
    {
        Task<ViewResult> task = Task.Run(() =>
        {
            using (SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer())
            {
                speechSynthesizer.Speak(text);
                return View();
            }
        });
        return await task;
    }
