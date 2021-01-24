    class FileReference
    {
        // elided 
       
        string File { get; } // may be set in constructor
        IEnumerable<int> Indices { get; } // will get the contents of _index
        public void Add(int index)
        {
            _indices.Add(index);
        }
    }
    class ReferenceIndex
    {
        Dictionary<string, FileReference> _fileReferences = new Dictionary<string, FileReference>();
        public void Add(string fileName, string index)
        {
            if(!_fileReferences.ContainsKey(fileName))
            {
                _fileReferences.Add(fileName, new FileReference(fileName));
            }
            _fileReferences[fileName].Add(index);
        }
        // elided
    }
