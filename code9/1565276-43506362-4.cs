    public class QualityChangedEventArgs:EventArgs
    {
        int OldQuality { get; set; }
        int NewQuality { get; set; }
        public QualityChangedEventArgs(int oldValue, int newValue)
        {
            OldQuality = oldValue;
            NewQuality = newValue;
        }
    }
