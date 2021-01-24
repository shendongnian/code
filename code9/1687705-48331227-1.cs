    public class FileSystemSomethingRepository : ISomethingRepository
    {
        private readonly string _sourceDirectoryPath;
        private readonly string _trainingDirectoryPath;
        private readonly string _testDirectoryPath;
        public FileSystemSomethingRepository(string sourceDirectoryPath, 
            string trainingDirectoryPath, 
            string testDirectoryPath)
        {
            _sourceDirectoryPath = sourceDirectoryPath;
            _trainingDirectoryPath = trainingDirectoryPath;
            _testDirectoryPath = testDirectoryPath;
        }
        public IEnumerable<ThingWithDataInIt> GetThings()
        {
            var filePaths = Directory.GetFiles(_sourceDirectoryPath);
            foreach (var filePath in filePaths)
            {
                var fileContent = File.ReadAllText(filePath);
                var deserialized = JsonConvert.DeserializeObject<ThingWithDataInIt>(fileContent);
                yield return deserialized;
            }
        }
        public void SaveAsTraining(ThingWithDataInIt thing)
        {
            // serialize it, write it to the folder
        }
        public void SaveAsTest(ThingWithDataInIt thing)
        {
            // serialize it, write it to the folder
        }
    }
