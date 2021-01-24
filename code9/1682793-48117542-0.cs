    class Test
    {
	    private static Crypto m_Crypto = null;
	    static Test()
	    {
		    m_Crypto = new Crypto("SOME_PASSWORD_HERE", "SOME_SALT_HERE");
    	}
    	public static void Write(string value)
    	{
    		File.WriteAllBytes(Application.persistentDataPath,
                               m_Crypto.Encrypt(Encoding.UTF8.GetBytes(value)));
    	}
    }
