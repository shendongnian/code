    /// <summary>There's only ever one background music source!</summary>
    public class BackgroundMusic {
        /// <summary>The static field - use AudioEngine.Current from anywhere.</summary>
        public static BackgroundMusic Current;
        /// <summary>Plays the given clip.</summary>
        public static void Play(AudioClip clip) {
           
            if (Current == null) {
                // It's not been setup yet - create it now:
                Current=new BackgroundMusic();
            }
            // E.g. Current.Source.Play(clip);
            
        }
        
        public BackgroundMusic() {
            // Instance a source now. 
        }
        
    }
