    public class ProcessFile
    {
        public ProcessFile(string filePath, IEnumerable<IFileProcessingTask> tasks)
        {
            FilePath = filePath;
            Tasks = tasks;
        }
        public string FilePath { get; }
        
        public IReadOnlyCollection<IFileProcessingTask> Tasks { get; }
    }
