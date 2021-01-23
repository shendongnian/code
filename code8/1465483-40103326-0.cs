    this class generate random number
    
    using System;
    using System.Security.Cryptography;
    
    class Program
    {
        static void Main()
        {
    	using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
    	{
    	    // Buffer storage.
    	    byte[] data = new byte[4];
    
    	    // Ten iterations.
    	    for (int i = 0; i < 10; i++)
    	    {
    		// Fill buffer.
    		rng.GetBytes(data);
    
    		// Convert to int 32.
    		int value = BitConverter.ToInt32(data, 0);
    		Console.WriteLine(value);
    	    }
    	}
        }
    }
