    private SpeechSynthesizer synth = new SpeechSynthesizer();
    private void SpeechButton_Click(object sender, RoutedEventArgs e)
    {
        // synth.Pause(); // maybe?
        
        // To me this reads like it will cancel other queued speech operations for this exact prompt. Maybe what you need
        synth.SpeakAsyncCancel("Hello, Welcome to the application");
        synth.Rate = 2;
    }
