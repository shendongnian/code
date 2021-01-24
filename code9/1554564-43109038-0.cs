    namespace System.Runtime.Loader
    {
        public class AssemblyLoadContext
        {
            // Allow to create an unloadable ALC. The default constructor
            // will call this method with false
            protected AssemblyLoadContext(bool unloadable);
    
            // Returns true if this ALC is collectible
            public bool Unloadable {get; }
    
            // Allows to explicitly unload an ALC. Once this method is called,
            // any call to LoadFromXXX method will throw an exception
            public void Unload();
        }
    }
