    public class MyTestClass
    {
        private FileType fileType;
        private string filename;
        public MyTestClass(FileType fileType, string filename)
        {
            this.fileType = fileType;
            this.filename = filename;
        }
        public void Execute()
        {
            Console.WriteLine(
                $"Extension = {fileType.Extension}, starting row = {fileType.StartingRow}");
        }
    }
