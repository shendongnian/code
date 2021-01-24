    class Program
    {
	static void Main(string[] argv)
	{
		int count ; 
		if ((argv.Length == 0) || !Int32.TryParse(argv[0], out count))
			count = 1;
		for (int i = 0; i < count; i++)
		{
			var keyConfig = GetASPNET20machinekey();
			Console.WriteLine(keyConfig);
		}
	}
	public static string GetRandomKey(int bytelength)
	{
		byte[] buff = new byte[bytelength];
		RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
		rng.GetBytes(buff);
		StringBuilder sb = new StringBuilder(bytelength * 2);
		for (int i = 0; i < buff.Length; i++)
			sb.Append(string.Format("{0:X2}", buff[i]));
		return sb.ToString();
	}
	public static string GetASPNET20machinekey()
	{
		StringBuilder aspnet20machinekey = new StringBuilder();
		string key64byte = GetRandomKey(64);
		string key32byte = GetRandomKey(32);
		aspnet20machinekey.Append("<machineKey \n");
		aspnet20machinekey.Append("validationKey=\"" + key64byte + "\"\n");
		aspnet20machinekey.Append("decryptionKey=\"" + key32byte + "\"\n");
		aspnet20machinekey.Append("validation=\"SHA1\" decryption=\"AES\"\n");
		aspnet20machinekey.Append("/>\n");
		return aspnet20machinekey.ToString();
	}
    }
