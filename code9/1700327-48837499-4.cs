    static public class ExtensionMethods
	{
		static public File WriteBytes(this File path, int offset, IEnumerable<byte> buffer)
		{
			//1. Check if file is open. If not, open it.
            //2. Now write to the file.
			return input;
		}
        static public void Commit(this File input)
        {
            //3. Close the file here
        }
	}
