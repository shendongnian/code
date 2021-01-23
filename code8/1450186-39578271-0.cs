    public static void Main (string[] args)
    		{
    			DataContractJsonSerializer serializer = new DataContractJsonSerializer(new Deck().GetType());
    
    			using (var stream = new MemoryStream())
    			{
    				serializer.WriteObject(stream, new Deck());
    				stream.Position = 0;//the key.
    				using (var sr = new StreamReader(stream))
    				{
    					Console.WriteLine(sr.ReadToEnd());
    				}
    			}
    		}
