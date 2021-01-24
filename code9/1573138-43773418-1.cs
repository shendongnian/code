    void Main()
    {
    	var fileHeader = new DataFileHeader()
    	{
    		Count = 10,
    		Id = 10,
    		Offset = 10,
    		Type = 10
    	};
    	
    	Serialize(fileHeader).Dump();
    }
    
    // Define other methods and classes here
    public byte[] Serialize<TObject>(TObject obj)
    {
    	BinaryFormatter binaryFormatter = new BinaryFormatter();
    	byte[] ret = null;
    	using (MemoryStream ms = new MemoryStream())
    	{
    		binaryFormatter.Serialize(ms, obj);
    		ret = ms.ToArray();
    	}
    	return ret;
    }
    
    [Serializable]
    public struct DataFileHeader
    {
    	public short Id;
    	public short Type;
    	public int Count;
    	public int Offset;
    };
