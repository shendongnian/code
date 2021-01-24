    public class CommentViewModel()
    {
        // I suppose CDate is a DateTime
        public DateTime CDate { get; set; }
    
        // If C# 6
        public PersianDate DateView => new PersianDate(CDate);
        // If < C#6
        public PersianDate DateView { get { return new PersianDate(CDate); } }
    }
