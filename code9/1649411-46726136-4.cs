    public class FileTransformEngine<TInput, TOutput>
    {
        public void TransformFileFast(string inputFile, string outputFile, 
                                          Func<TInput,TOutput> transformer)
        {
           var readEngine = new FixedFileEngine<TInput>();
           TInput[] records = readEngine.ReadFile(inputFile);
           IEnumerable<TOutput> outputRecords = records.Select(transformer);
           var writeEngine = new FileHelperEngine<TOutput>();
           writeEngine.WriteFile(outputFile,outputRecords );       
    
        }
    }
