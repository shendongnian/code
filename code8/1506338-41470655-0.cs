    public class MessageReader : IDisposable {
       private readonly Message message;
    
       public MessageReader(ref Message originalMessage) {
    
          using( var buffer = originalMessage.CreateBufferedCopy( int.MaxValue ) ) {
    
             // Keep original message for reading 
             this.message = buffer.CreateMessage();
    
             // Set original message to a copy of the original
             originalMessage = buffer.CreateMessage();
          }
       }
    
       public int ReadSomething(string id) {
           
           // Read from this.message;  
       }
    
       public int ReadSomethingElse(string id) {
           // Read from this.message;    
       }
    
       public void Close() {
          this.Dispose();
       }
    
       public void Dispose() {
    
          this.message.Close();
       }
    }
