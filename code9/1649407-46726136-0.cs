    public class FileTransformEngine<T>
    {
        public void TransformFileFast(string inputFile, string outputFile)
        {
           var readEngine = new FixedFileEngine<T>();
           T[] records = readEngine.ReadFile(inputFile);
           var writeEngine = new FileHelperEngine<T>();
           writeEngine.WriteFile(outputFile,records);       
    
        }
    }
