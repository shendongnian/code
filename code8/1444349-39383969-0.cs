    using System.Linq;
    class Foo
    {
        public int A { get; set; }
        public char B { get; set; }
        public string C { get; set; }
        public Guid GetGuid()
        {
            byte[] aBytes = BitConverter.GetBytes(A);
            byte[] bBytes = BitConverter.GetBytes(B);
            byte[] cBytes = BitConverter.GetBytes(C);
            byte[] padding = new byte[16];
            byte[] allBytes =
                aBytes
                    .Concat(bBytes)
                    .Concat(cBytes)
                    .Concat(padding)
                    .Take(16)
                    .ToArray();
            return new Guid(allBytes);
        }
    }
