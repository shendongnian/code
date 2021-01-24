        public class SimpleClass2: IDisposable
    {
        // managed resources
        private SqlConnection _connection;
        private bool _disposed;
        // unmanaged resources
        private IntPtr _unmanagedResources;
        
        // simple method for the demo
        public string GetDate()
        {
            // One good practice that .NET Framework implies is that when object is being disposed
            // trying to work with its resources should throw ObjectDisposedException so..
            if(_disposed) { throw new ObjectDisposedException(this.GetType().Name);}
            if (_connection == null)
            {
                _connection = new SqlConnection("Server=.\\SQLEXPRESS;Database=master;Integrated Security=SSPI;App=IDisposablePattern");
                _connection.Open();
            }
            // allocation of unmanaged resources for the sake of demo.
            if (_unmanagedResources == IntPtr.Zero)
            {
                _unmanagedResources = Marshal.AllocHGlobal(100 * 1024 * 1024);
            }
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "SELECT getdate()";
                return command.ExecuteScalar().ToString();
            }
        }
        public void Dispose()
        {
            // Here in original Dispose method we call protected method with parameter true,
            // saying that this object is being disposed.
            this.Dispose(true);
            
            // Then we "tell" garbage collector to suppress finalizer for this object because we are releasing
            // its memory and doesnt need to be finalized. Calling finalizer(destructor) of a given type is expensive
            // and tweaks like this help us improve performance of the application.
            
            // This is only when your class doesnt have unmanaged resources!!!
            // Since this is just made to be a demo I will leave it there, but this contradicts with our defined finalizer.
            GC.SuppressFinalize(this);
        }
        // Following the best practices we should create another method in the class 
        // with parameter saying wether or not the object is being disposed.
        // Its really important that this method DOES NOT throw exceptions thus allowing to be called multiple times 
        protected virtual void Dispose(bool disposing)
        {
            // another thing we may add is flag that tells us if object is disposed already
            // and use it here
            if (_disposed) { return; }
            // Thus Dispose method CAN NOT release UNMANAGED resources such as IntPtr structure,
            // flag is also helping us know whether we are disposing managed or unmanaged resources
            if (disposing)
            {
                if (_connection != null)
                {
                    _connection.Dispose();
                    _connection = null;
                }
                _disposed = true;
            }
            // Why do we need to do that?
            // If consumer of this class forgets to call its Dispose method ( simply by not using the object in "using" statement
            // Nevertheless garbage collector will fire eventually and it will invoke Dispose method whats the problem with that is if we didn't 
            // have the following code unmanaged resources wouldnt be disposed , because as we know GC cant release unmanaged code.
            // So thats why we need destructor(finalizer).
            if (_unmanagedResources != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(_unmanagedResources);
                _unmanagedResources = IntPtr.Zero;;
            }
            // call base Dispose(flag) method if we are using hierarchy.
        }
        ~DatabaseStateImpr()
        {
            // At this point GC called our finalizer method , meaning 
            // that we don't know what state our managed resources are (collected or not) because
            // our consumer may not used our object properly(not in using statement) so thats why
            // we skip unmanaged resources as they may have been finalized themselves and we cant guarantee that we can
            // access them - Remember? No exceptions in Dispose methods.
            Dispose(false);
        }
    }
