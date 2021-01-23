    public MessageReader: IDisposable
    {
         public static MessageReader Create(ref Message message)
         {
             var reader = new MessageReader(message.CreateBufferedCopy(/*whatever is fit*/));
             message = buffer.CreateMessage();
             return reader;
         }
         private readonly MessageBuffer buffer;
         private bool disposed;
         private MessageReader(MessageBuffer buffer) { this.buffer = buffer; }
         public void Dispose()
         {
             if (disposed)
                 return;
             buffer.Close();
             disposed = true;
         }
         public string Read(string id)
         {
              var newCopy = buffer.CreateCopy();
              //work with new copy...
         }
    }
