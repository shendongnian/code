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
    }
