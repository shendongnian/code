    class Foo
    {
        IReadOnlyList<string> sharedResource = new List<string>();
    
        public void reading()
        {
            // Here you can safely* read from sharedResource
        }
    
        public void mutating()
        {
            var copyOfData = new List<string>(sharedResource);
    
            // modify copyOfData here
    
            Interlocked.Exchange(ref sharedResource, copyOfData);
        }
    }
