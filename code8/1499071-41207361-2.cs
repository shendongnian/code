    public class DLLTestClass : IDllTest
    {
        public bool DLLTestFunction(FileInfo file)
        {
            return file.Exists;
        }
    }
