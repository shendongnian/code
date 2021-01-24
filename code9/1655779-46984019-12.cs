        public class ProgressEventArgs :EventArgs
        {
            public int CurrentProgress { get; }
            public ProgressEventArgs(int progress)
            {
                CurrentProgress = progress;
            }
        }
