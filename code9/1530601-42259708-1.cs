    class Talker
    {
        public void TellMe(string message, Speaker speaker)
        {
            speaker.Data = message.Length;
        }
    }
