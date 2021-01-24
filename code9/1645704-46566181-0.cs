    public abstract class MyInterface
    {
        public abstract ICollection<Translation> FileTypeTranslations { get; set; }
    }
    
    public class FileType : MyInterface
    {
        public override ICollection<Translation> FileTypeTranslations { get; set; }
    }
