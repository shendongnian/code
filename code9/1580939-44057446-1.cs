    public class MyPackage
    {
    	public int Length => 12; // or 16 if Length is included
    
    	public int Id { get; set; }
    
    	public int Number1 { get; set; }
    
    	public int Number2 { get; set; }
    
    	public byte[] SerializeToBinary()
    	{
    		using (var memoryStream = new MemoryStream())
    		using (var writer = new BinaryWriter(memoryStream))
    		{
    
    			writer.Write(Length);
    			writer.Write(Id);
    			writer.Write(Number1);
    			writer.Write(Number2);
    			
    			return memoryStream.ToArray();
    		}
    	}
    
    	public void DeserializeFromBinary(byte[] data)
    	{
    		using(var memoryStream = new MemoryStream(data))
    		using(var reader = new BinaryReader(memoryStream))
    		{
    			var length = reader.ReadInt32();
    			if (length != Length)
    				throw new Exception("Some error if you care about length");
    
    			Id = reader.ReadInt32();
    			Number1 = reader.ReadInt32();
    			Number2 = reader.ReadInt32();
    		}
    	}
    }
