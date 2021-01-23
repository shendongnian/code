    public class Matrix
        {
            private IFileWriter _writer;
    
            public Matrix(IFileWriter writer)
            {
                 _writer = writer;
            }
    
            public void Generate()
            {
                //Generate Step 1
    
                //for the debug I want to use this method sometime
                _writer.WriteToFile();
    
                //Generate Step 2
            }
    
            
        }
