    public interface IFile
    {
        string path { get; set; } // <--- GetHashCode doesn't need to be in here.
    }
    public interface IFiles : IEnumerable<IFile>
    {
        IEnumerable<IFile> GetFiles();
        ResourceType resourceType { get; } // <-- Getter only here on the interface
    }
    public interface IFiles<out T> : IFiles
        where T : IFile  // <-- This will enforce the same file type in this collection
    {
        new IEnumerable<T> GetFiles();
    }
