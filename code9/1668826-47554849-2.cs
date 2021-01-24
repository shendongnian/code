    public sealed class BlobAccessClients
    {
        public readonly IBlobAccessClient Src;
        public readonly IBlobAccessClient Dest;
        public BlobAccessClients(IBlobAccessClient src, IBlobAccessClient dest)
        {
            this.Src = src;
            this.Dest = dest;
        }
    }
