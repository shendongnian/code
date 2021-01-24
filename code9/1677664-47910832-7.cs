    public class ImageFile : IFile
    {
        public string path { get; set; }
        public override int GetHashCode()
        {
            return path.GetHashCode();
        }
    }
    public class ImageFiles : IFiles<ImageFile>
    {
        public ImageFiles(IEnumerable<ImageFile> files)
        {
            this.files = files.ToList();
        }
        public bool mySpecialProperty { get; set; } // <--- ImageFiles special, Not in Media nor Image
        public ResourceType resourceType => ResourceType.Image;
        private List<ImageFile> files;
        public IEnumerable<IFile> GetFiles()
        {
            return files;
        }
        IEnumerable<ImageFile> IFiles<ImageFile>.GetFiles()
        {
            return files;
        }
        public IEnumerator<IFile> GetEnumerator()
        {
            return files.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public override int GetHashCode()
        {
            return files.GetHashCode();
        }
    }
