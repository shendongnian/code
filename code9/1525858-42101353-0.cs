    public class Mail
    {
        public int MailId { get; set; }
    
        public virtual ICollection<File> Files { get; set; }
    }
    public class File
    {
        public int FileId { get; set; }
    
        public int MailId { get; set; }
        public virtual Mail Mail { get; set; }
    }
