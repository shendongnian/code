    static public class ExtensionMethods
	{
		static public File WriteBytes(this File path, int offset, IEnumerable<byte> buffer)
		{
			OpenFile(path);    //Just as an example
            SeekIndex(offset); //Just as an example
            Write(buffer);     //Just as an example
            CloseFile();       //Just as an example
			return path;
		}
	}
