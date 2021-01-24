    public class WaveOutPlayer {
        private readonly SynchronizationContext _context;
        public WaveOutPlayer() {
            // capture
            _context = SynchronizationContext.Current;
        }
        public event EventHandler<AudioEventArgs> BufferSwapped;
        private void passAudio(byte[] pAudioData) {
            var args = new AudioEventArgs();
            args.Data = pAudioData;
            var handler = BufferSwapped;
            if (handler != null) {
                if (_context != null)
                    // post
                    _context.Post(_ => handler(this, args), null);
                else
                    handler(this, args);
            }
        }
    }
