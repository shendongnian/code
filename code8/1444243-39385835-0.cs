    public abstract class FileProcessorBase
    {
        protected  IFileReaderFactory _fileReaderFactory;
        protected  FooDbContext _fooDb;
        public void ProcessFile(string source, string filePath)
        {
            _fooDb.Foos.AddRange(GetFileReader().ReadFile(filePath));
            _fooDb.SaveChanges();
        }
        protected abstract IFileReader GetFileReader();
    }
    public class FileProcessorA : FileProcessorBase
    {
        public FileProcessorA(IFileReaderFactory fileReaderFactory, FooDbContext fooDb)
        {
            _fileReaderFactory = fileReaderFactory;
            _fooDb = fooDb;
        }
        protected override IFileReader GetFileReader()
        {
            return _fileReaderFactory.CreateReader<FileReaderA>();
        }
    }
    public class FileProcessorB : FileProcessorBase
    {
        public FileProcessorB(IFileReaderFactory fileReaderFactory, FooDbContext fooDb)
        {
            _fileReaderFactory = fileReaderFactory;
            _fooDb = fooDb;
        }
        protected override IFileReader GetFileReader()
        {
            return _fileReaderFactory.CreateReader<FileReaderB>();
        }
    }
