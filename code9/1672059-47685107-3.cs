    public class MyTestClass
    {
        private FileType fileType;
        public MyTestClass(FileType fileType)
        {
            this.fileType = fileType;
        }
        public string Filename { get; set; }
        public void Execute()
        {
            ...
        }
    }
