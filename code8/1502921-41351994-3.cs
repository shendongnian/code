    public class FileObject
    {
        public readonly int Id;
        public readonly string Filename;
        FileObject(int id, string fileName)
        {
            Id = id;
            Filename = fileName;
        }
        public static FileObject New(int id, string fileName) =>
            new FileObject(id, fileName);
    }
