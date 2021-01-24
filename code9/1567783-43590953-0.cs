    public class ChapterFrame : Frame
    {
        private Header Header { get; set; }
        private string ElementId { get; set; }
        private TimeSpan StartTime { get; set; }
        private TimeSpan EndTime { get; set; }
        private TimeSpan StartOffset { get; set; }
        private TimeSpan EndOffset { get; set; }
        private List<ChapterFrame> Subframes = new List<ChapterFrame>();
    }
