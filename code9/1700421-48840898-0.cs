        var buffer = new byte[1024 * 1024]; // 1MB buffer
        using (var encryptedStream = new FileStream("FileName.ext.aes", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None, buffer.Length, FileOptions.Asynchronous))
        {
          using (var crypto = new CryptoStream(encryptedStream, encryptor, CryptoStreamMode.Write))
          {
            using (var unencryptedStream = new FileStream("FileName.ext", FileMode.Open, FileAccess.Read, FileShare.Read, buffer.Length, FileOptions.Asynchronous))
            {
              int bytesRead;
              do
              {
                bytesRead = await unencryptedStream.ReadAsync(buffer, 0, buffer.Length);
                await crypto.WriteAsync(buffer, 0, bytesRead);
              } while (bytesRead == buffer.Length);
            }
          }
        }
