		static void Test1()
		{
			
			string[] files = Directory.GetFiles(@"D:\_test", "*", SearchOption.AllDirectories);
			EncryptionFile enc = new EncryptionFile();
			//DecryptionFile dec = new DecryptionFile();
				 
			string password = "abcd";
			for (int i=0; i<files.Length; i++)
			{
				Console.WriteLine(files[i]);
				enc.EncryptFile(files[i], password);
				//dec.DecryptFile(files[i], password);
			}
		}
