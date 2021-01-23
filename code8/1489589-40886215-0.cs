    public interface IParsedFile
    {
        void OnOpen();
        void OnLineParsed(string line);
        void OnClosed();
    }
    public class FileParseManager
    {
        private readonly FileParser _fileParser;
        private readonly List<IParsedFile> _parsedFiles;
        public FileParseManager(FileParser fileParser, List<IParsedFile> parsedFiles)
        {
            _fileParser = fileParser;
            _parsedFiles = parsedFiles;
        }
        public void Parse(string fileName)
        {
            _fileParser.OpenFile(string fileName);
            foreach (var parsedFile in _parsedFiles)
            {
                parsedFile.OnOpen();
            }
            while ((string line = _fileParser.GetNextLine()) != null)
            {
                foreach (var parsedFile in _parsedFiles)
                {
                    parsedFile.OnLineParsed(line);
                }
            }
            _fileParser.CloseFile();
            foreach (var parsedFile in _parsedFiles)
            {
                parsedFile.OnClosed();
            }
        }
    }
