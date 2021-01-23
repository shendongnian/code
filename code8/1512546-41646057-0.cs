    // Voice.cs
    public class Voice
    {
        public SpeechSynthesizer synth;
        public Voice()
        {
            Start();
        }
        
        public void Start()
        {
            synth = new SpeechSynthesizer();
            synth.SetOutputToDefaultAudioDevice();
        }
    
        public void Say(string speech)
        {
            synth.SpeakAsync(speech);
        }
    }
