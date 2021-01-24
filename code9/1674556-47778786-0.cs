    public class Pak10File : PakFileFormat<Pak10FileEntry>
    {    
        public Pak10File()
        {
            this.toc = new PakFileToc<Pak10FileEntry>();
        }
    }
