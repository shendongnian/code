    private static int COLLISION_LENGTH = 5;
	public static string CreateCollision(string oldValue)
    {
        var chars = new char[COLLISION_LENGTH];
        for(int i = 0; i < oldValue.Length; i++)
		{
			chars[i % chars.Length] ^= oldValue[i];
		}
		
		return new String(chars);
    }
