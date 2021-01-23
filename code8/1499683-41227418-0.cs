    public class IntArrayOverBytes
	{
	    private readonly byte[] bytes;
		public IntArrayOverBytes(byte[] bytes)
		{
		    this.bytes = bytes;
	    }
		public int this[int index]
		{
		    get { return BitConverter.ToInt32(bytes, index * 4); }
			set { Array.Copy(BitConverter.GetBytes(value), 0, bytes, index * 4, 4); }
	    }
    }
