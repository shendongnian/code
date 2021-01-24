    public abstract class FileWatcher
    {
        // last known position of the stream 
        int m_LastStreamPosition;
        // flag to check if file is currently in read state
        volatile bool m_IsReading;
    
        // info about the file
        FileInfo m_FileInfo;
        // file system watcher 
        FileSystemWatcher m_Watcher;
    
        // standard ctor used to watch specific file
        public FileWatcher(string filePath)
        {
            // create new instance of FileSystem using the path of the file
            m_FileInfo = new FileInfo(filePath);
            // if ( !m_FileInfo.Exists ) throw new InvalidArgumentException("filePath");
            // start watcher based on the FileInfo
            m_Watcher = new FileSystemWatcher(m_FileInfo.DirectoryName, m_FileInfo.Extension);
            m_Watcher.EnableRaisingEvents = true;
            m_Watcher.Changed += WhenFileChanged;
    
            // reset stream position and read file initialy
            m_LastStreamPosition = 0;
            ReadFile();
        }
    
        // event fired when file is changed
        // !! note that this will fire whenever you create file in the same
        //    directory as your desired file is and with the same extension
        //    and then change/modify this file
        void WhenFileChanged(object source, FileSystemEventArgs e)
        {
            // based on the note comment, check if that's our desired file
            if ( e.FullPath != m_FileInfo.FullName ) return;
            // refresh informations about the file
            m_FileInfo.Refresh();
            // check if something was added to the file,
            // in case something was removed (?) reset lastStreamPosition (?)
            if ( m_FileInfo.Length <= m_LastStreamPosition )
                m_LastStreamPosition = 0;
            
            // read the file
            ReadFile();
        }
    
        void ReadFile()
        {
            if ( m_IsReading ) return;
            m_IsReading = true;
            using ( StreamReader reader = m_FileInfo.OpenText() )
            {
                reader.BaseStream.Position = m_LastStreamPosition;
                string line = string.Empty;
                while ( ( line = reader.ReadLine() ) != null )
                {
                    ProcessLine(line);
                }
                m_LastStreamPosition = reader.BaseStream.Position;
            }
            m_IsReading = false;
        }
        protected abstract void ProcessLine(string line);
    }
