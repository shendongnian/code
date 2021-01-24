    namespace so42248850
    {
        class Program
        {
            class someClass
            {
                public byte[] DocumentFile;
            }
            static void Main(string[] args)
            {
                var oversized = new byte[41943041]; /* 40 MB plus the last straw */
                var mock = new someClass
                {
                    DocumentFile = oversized
                };
            }
        }
    }
