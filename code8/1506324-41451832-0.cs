    public MessageReader: IDisposable
    {
         public static MessageReader Create(ref Message message)
         {
             var reader = new MessageReader(message.CreateBufferedCopy(0));
             message = buffer.CreateMessage();
             return reader;
         }
         private readonly MessageBuffer buffer;
         private MessageReader(MessageBuffer buffer) { this.buffer = buffer; }
         public void Dispose()
         {
             if (disposed)
                 return;
             buffer.Close();
         }
         public string Read(string id)
         {
              var newCopy = buffer.CreateCopy();
              //work with new copy...
         }
    }
