    public unsafe class PinnedArray : IDisposable
    {
        byte[] values;
        byte* pointer;
        GCHandle handle;
        public PinnedArray(int size)
        {
            values=new byte[size];
            handle=GCHandle.Alloc(values, GCHandleType.Pinned);
            pointer=(byte*)handle.AddrOfPinnedObject().ToPointer();
        }
        ~PinnedArray()
        {
            Dispose();
        }
        public void Dispose()
        {
            if(values!=null)
            {
                handle.Free();
                values=null;
            }
        }
        // This is fast because it uses pointers
        public void AddFrom(PinnedArray other)
        {
            if(values.Length!=other.values.Length)
            {
                throw new ArgumentException("other");
            }
            for(int i = 0; i<values.Length; i++)
            {
                pointer[i]+=other.pointer[i];
            }
        }        
        public void FillRandom()
        {
            Random rand = new Random();
            for(int i = 0; i<values.Length; i++)
            {
                values[i]=(byte)(rand.Next()%256);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var A = new PinnedArray(100);
            var B = new PinnedArray(100);
            B.FillRandom();
            A.AddFrom(B);
        }
    }
