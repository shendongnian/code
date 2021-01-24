    public interface IFileHelperEngine<T> where T : class
    {
        T[] ReadFile(string inputFileName);
    }
    
    public class Handler<T> : IHandler<T> where T : class
    {
        private IFileHelperEngine<T> fileHelperEngine;
        public Handler(IFileHelperEngine<T> fileHelperEngine) //<----See this.
        {
            this.fileHelperEngine = fileHelperEngine;
        }
        public T[] parseCSV(string InputFileName)
        {
            if (File.Exists(InputFileName))
            {
                _inputFileName = InputFileName;
                return this.fileHelperEngine.ReadFile(_inputFileName); //<--and this
            }
            throw new IOException($"{InputFileName} not found!");
        }
    }
