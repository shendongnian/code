    public class NameToBeDetermined : IDisposable
    {
        private ZipFile zip;
        public Stream Stream { get; }
        public NameToBeDetermined(ZipFile zip, Stream stream)
        {
            this.zip = zip;
            Stream = stream;
        }
        public void Dispose()
        {
            zip.Dispose();
            Stream.Dispose();
        }
    }
