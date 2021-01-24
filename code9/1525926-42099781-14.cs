    /// <summary>There's only ever one background music source!
    /// It has instance properties though (i.e. an AudioSource)
    /// so it works well as a singleton.</summary>
    public class BackgroundMusic {
        /// <summary>The static field - use the Play method from anywhere.</summary>
        private static BackgroundMusic Current;
        /// <summary>Plays the given clip.</summary>
        public static void Play(AudioClip clip) {
           
            if (Current == null) {
                // It's not been setup yet - create it now:
                Current = new BackgroundMusic();
            }
            // E.g. Current.Source.Play(clip);
            
        }
        
        public BackgroundMusic() {
            // Instance a source now. 
        }
        
    }
