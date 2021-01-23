    public MessageReader: IDisposable
    {
         public static MessageReader Create(ref Message message)
         {
             var buffer = message.CreateBufferedCopy(/*whatever is fit*/);
             try
             {
                 var reader = new MessageReader(buffer);
                 message = buffer.CreateMessage();
                 return reader;
             }
             catch
             {
                 buffer.Close();
                 throw;
             }
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
              var newCopy = buffer.CreateMessage();
              //work with new copy...
         }
    }
