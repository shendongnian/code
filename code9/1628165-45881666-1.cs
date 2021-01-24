    public class Sources {
        private readonly IDirectory _directory;
        private readonly IFile _file;
        private readonly IJsonSerializer serializer; 
    
        public Sources(IDirectory directory, IFile file, IJsonSerializer serializer) {
            _directory = directory;
            _file = file;
            this.serializer = serializer;
        }
    
        public LibrarySource GetSource(string filePath) {
            var sourceDto = serializer.Deserialize<LibrarySourceDto>(_file.ReadAllText(filePath));
            return SourceMapper.Map(sourceDto);
        }
    }
