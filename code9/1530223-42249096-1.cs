    namespace so42248850
    {
        class Program
        {
            class someClass
            {
                /* [attributes...] */
                public byte[] DocumentFile;
            }
            static void Main(string[] args)
            {
                var oversized = new byte[41943041]; /* 40 MB plus the last straw */
                try
                {
                    var mock = new someClass
                    {
                        DocumentFile = oversized
                    };
                } 
                catch(Exception e)
                {
                    /* is this the expected exception > test passes/fails */
                }
            }
        }
    }
