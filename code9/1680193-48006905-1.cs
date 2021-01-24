    namespace testApp
    {
      public class testclass : IDisposable
      {
          bool disposed = false;
         //Instantiate a SafeHandle instance.
          SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
       { 
         Dispose(true);
         GC.SuppressFinalize(this);           
       }
    
       // Protected implementation of Dispose pattern.
       protected virtual void Dispose(bool disposing)
       {
         if (disposed)
          return; 
         if (disposing) {
          handle.Dispose();
          // Free any other managed objects here.
          //
        }
    
        // Free any unmanaged objects here.
         //
        disposed = true;
       }  
    
    
        public void welcome()
        {
             //some code goes here
         }
       }
     }
      
    private void button1_Click(object sender, EventArgs e)
    {
           using (var obj = new testclass())
           {
           }
     }
