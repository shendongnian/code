    public class ThreadSafeStringBuilder 
    {
       private readonly StringBuilder core = .....
       private readonly ReaderWriterLockSlim sync = ....
    
       public void Append(String str) {
          try {
             this.sync.EnterWriterLock();
             this.core.Append(str);
          }
          finally {
             this.sync.ExitWriterLock()
          }
        }
      public override ToString() {
        try {
           this.sync.EnterReadLock();
           return this.core.ToString();
        }
        finnaly {
           this.sync.ExitReadLock()
        }
      }
    }
