    public void CreateFile(string path)
    {
        Task<byte[]>[] tasks = new [] { 
              Task.Run((byte[])CreateHeaderAsync), 
              Task.Run((byte[])CombineFilesAsync)};
        
        // rest of the method 
    }
    private byte[] CombineFilesAsync()
    {
         ByteFile[] arrays = _files.ToArray();
         byte[] rv = new byte[arrays.Sum(a => a.Length)];
         int offset = 0;
         foreach (ByteFile t in arrays)
         {
            var array = Encryption.EncryptBytes(t.Content, "password");
            Buffer.BlockCopy(array, 0, rv, offset, array.Length);
            offset += array.Length;
         }
         return rv;
    }
