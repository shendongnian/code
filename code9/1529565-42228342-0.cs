    public class MyXmlManipulator : IDisposable
    {
        private FileStream fileStream;
        // ...
        public void ManipulateXml()
        {
            // your original codes here...
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~MyXmlManipulator()
        {
            Dispose(false);
        }
        protected virtual Dispose(bool disposing)
        {
            fileStream.Close();
            // etc...
        }
    }
