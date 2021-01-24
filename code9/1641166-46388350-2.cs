		private void buttonCrypt_Click(object sender, EventArgs e)
		{
			ICryptoTransform transform;
			AesManaged Aes = new AesManaged();
			Aes.KeySize = 256;
			Aes.BlockSize = 128;
			Aes.Mode = CipherMode.CBC;
			Aes.Padding = PaddingMode.PKCS7;
			transform = Aes.CreateEncryptor();
			key = (byte[])Aes.Key.Clone();
			iv = (byte[])Aes.IV.Clone();
			generalizationofwrittendata("plain.bin",testdata.Length,1,encryptedFile,transform,testdata,0x0abbccdd,0x01223344,0x09887766);
		}
		private void buttonDecrypt_Click(object sender, EventArgs e)
		{
			AesManaged Aes = new AesManaged();
			Aes.KeySize = 256;
			Aes.BlockSize = 128;
			Aes.Mode = CipherMode.CBC;
			Aes.Padding = PaddingMode.PKCS7;
			var transform = Aes.CreateDecryptor(key, iv);
			test(encryptedFile, testdata.Length, 1, "decrypted.bin", transform);
		}
