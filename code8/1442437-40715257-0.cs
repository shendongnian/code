    [MessageContract]
        public class RemoteFileInfo : IDisposable
        {
            [MessageHeader(MustUnderstand = true)]
            public string FileName;
    
            [MessageHeader(MustUnderstand = true)]
            public string DocType;
    
            [MessageHeader(MustUnderstand = true)]
            public string CustomerKey;
    
            [MessageHeader(MustUnderstand = true)]
            public string DocumentId;
    
            [MessageBodyMember(Order = 1)]
            public System.IO.Stream FileByteStream;
    
            public void Dispose()
            {
                if (FileByteStream != null)
                {
                    FileByteStream.Close();
                    FileByteStream = null;
                }
            }
        }
    [MessageContract]
    public class RemoteResponse
    {
        [MessageBodyMember(Order = 1)]
        public string Token;
    }
