    SpeechSynthesizer s = new SpeechSynthesizer();
    SpeechRecognizer rec = new SpeechRecognizer();
    private void Form1_Load(object sender, EventArgs e)
    {
        rec.SpeechRecognized += rec_SpeechRecognized;
        rec.PauseRecognizerOnRecognition = true;
    }
    private void rec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
    {
        richTextBox1.AppendText(e.Result.Text);
        if (e.Result.Text.Contains("hello"))
        {
            s.Speak("hi");
        }
    }
