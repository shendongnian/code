    [HttpPost]
    public async Task<ActionResult> TTS(string text)
    {
        // you can set output file name as method argument or generated from text
        string fileName = "fileName";
        Task<ViewResult> task = Task.Run(() =>
        {
            using (SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer())
            {
                speechSynthesizer.SetOutputToWaveFile(Server.MapPath("~/path/to/file/") + fileName + ".wav");
                speechSynthesizer.Speak(text);
                ViewBag.FileName = fileName + ".wav";
                return View();
            }
        });
        return await task;
    }
