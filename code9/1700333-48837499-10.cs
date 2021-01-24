    static public class ExtensionMethods
	{
		static public File WriteBytes(this File path, int offset, IEnumerable<byte> buffer)
		{
            if (!IsFileOpen) OpenFile(path);    
            SeekIndex(offset); 
            Write(buffer);     
			return path;
		}
        static public void Commit(this File path)
        {
            CloseFile();  
        }
	}
