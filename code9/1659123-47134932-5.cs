    public interface IErrorLogsMetaData
    {
        [Display(Name = "Id")]
        long pk { get; set; }
        [Display(Name = "The line Number")]
        int lineNumber { get; set; }
        [Display(Name = "The Error")]
        Nullable<int> error { get; set; }
    }
