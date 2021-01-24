    private SpeechSynthesizer synth = new SpeechSynthesizer();
    private void SpeechButton_Click(object sender, RoutedEventArgs e)
    {
        // Cancel the current speak operation and all queued SpeakAsync operations.
        synth.SpeakAsyncCancelAll();
          
        // Begin speaking the prompt.
        synth.SpeakAsync("Hello, Welcome to the application");
    }
