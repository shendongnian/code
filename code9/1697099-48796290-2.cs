    public MyClass() { this.reader = new TextReader(); }
    
    public class A : IDisposable   
    {
        bool disposed = false;  // Flag: Has Dispose already been called?
    	private Component handle;
    	private IntPtr umResource;
        public void Dispose()   {      
                    Dispose(true);   GC.SuppressFinalize(this);   }
        protected virtual void Dispose(bool disposing) {
                	if (disposed) return;
                    if (disposing) {   			// Free managed resources
                            if (reader != null) reader.Dispose(); 
                            if (handle != null) handle.Close(); }
                	if (umResource != IntPtr.Zero) { // Free unmanaged resources
                    			umResource = IntPtr.Zero; }
                    disposed = true;   }  
        ~A() { Dispose(false); }   } // Only if we have real unmanaged resources
