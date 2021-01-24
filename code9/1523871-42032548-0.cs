    public class IoBase : IDisposable
    {
      public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
        }
    }
    public class FileIo: IoBase
    {
        private Stream io = new FileStream("c:\tmp\tmp.txt", FileMode.OpenOrCreate);
    }
    public class FileIo2 : IDisposable
    {
        private Stream io = new FileStream("c:\tmp\tmp.txt", FileMode.OpenOrCreate);
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
        }
    }
