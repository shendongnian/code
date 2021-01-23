    public static class MyItemSerializer
    {
    	public static byte[] Serialize(this IEnumerable<MyItem> items)
    	{
    		using (MemoryStream m = new MemoryStream()) 
    		{
                using (BinaryWriter writer = new BinaryWriter(m, System.Text.Encoding.UTF8, true)) 
    			{
    				foreach (var item in items) 
    				{
    					var itemBytes = item.Serialize();
    					writer.Write(itemBytes.Length);
    					writer.Write(itemBytes);
    				}
    				
    			}
    			
    			return m.ToArray();
    		}
    	}
    	
    	public static List<MyItem> Deserialize(byte[] data)
    	{
    		var ret = new List<MyItem>();
    		using (MemoryStream m = new MemoryStream(data))
    		{
                using (BinaryReader reader = new BinaryReader(m, System.Text.Encoding.UTF8)) 
    			{
    				while (m.Position < m.Length)
    				{
    					var itemLength = reader.ReadInt32();
    					var itemBytes = reader.ReadBytes(itemLength);
    					var item = MyItem.Desserialize(itemBytes);
    					ret.Add(item);
    				}
    			}
    		}
    		
    		return ret;
    	}
    }
