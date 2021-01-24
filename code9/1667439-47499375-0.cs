    public class Speaker : Java.Lang.Object, TextToSpeech.IOnInitListener
    {
        private readonly TextToSpeech speaker;
    
        public Speaker(Context context)
        {
            speaker = new TextToSpeech(context, this);
            // Don't use speaker.Voices here because it hasn't
            // been initialized. Wait for OnInit to be called.
        }
    
        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                // Iterating the collection with a foreach
                // is perfectly fine.
                foreach (var voice in speaker.Voices)
                {
                    // Do whatever with the voice
                }
            }
        }
    }
