    public class QualityChangedEventArgs:EventArgs
    {
        public int OldQuality { get; set; }
        public int NewQuality { get; set; }
        public QualityChangedEventArgs(int oldValue, int newValue)
        {
            OldQuality = oldValue;
            NewQuality = newValue;
        }
    }
