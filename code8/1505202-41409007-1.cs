	public static async Task<string> decrypt(string encrypted, string privateKey) {
            // read private certificate into RSACryptoServiceProvider from file
			RSACryptoServiceProvider rsa = DecodePrivateKeyInfo( DecodePkcs8PrivateKey( File.ReadAllText( privateKey ) ) );
            // decode base64 to bytes
			byte[] encryptedBytes = Convert.FromBase64String( encrypted );
			int bufferSize = (int)(rsa.KeySize / 8);
            // initialize byte buffer based on certificate block size
			byte[] buffer = new byte[bufferSize]; // the number of bytes to decrypt at a time
			int bytesReadTotal = 0;    int bytesRead = 0;
			string decrypted = "";     byte[] decryptedBytes;
    
            // convert byte array to stream
			using ( Stream stream = new MemoryStream( encryptedBytes ) ) {
                // loop through stream for each block of 'bufferSize'
				while ( ( bytesRead = await stream.ReadAsync( buffer, bytesReadTotal, bufferSize ) ) > 0 ) {
                    // decrypt this chunk
					decryptedBytes = rsa.Decrypt( buffer, false );
                    // account for bytes read & decrypted
					bytesReadTotal = bytesReadTotal + bytesRead;
                    // append decrypted data as string for return
					decrypted = decrypted + Encoding.UTF8.GetString( decryptedBytes );
				}
			}
			return decrypted;
	}
