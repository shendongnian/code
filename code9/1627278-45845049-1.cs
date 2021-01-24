    public class LibrarySource 
    {    
        public string Path { get; set; }  
        private SourceState State { get; }
        public class Synchroniser 
        {
            LibrarySource _librarySource;
            public Synchroniser(LibrarySource source){
                _librarySource = source;
            }
            public Task SyncAsync(){
                // At start of sync, set _librarySource.State = Updating
                // At end of sync, set _librarySource.State = Ready
            }
        }
    }
