    class Speaker
    {
        public int Data { get; set; }
        public void SpeakTo(Elephant whoToTalkTo, string message) 
        {
            // Passing current instance of this class as the argument
            whoToTalkTo.TellMe(message, this);
        }
    }
