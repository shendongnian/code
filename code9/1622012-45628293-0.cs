    public static class DbEncryptionHandler
    {
       public static string DynamicEncrypt(string clearText, IEnumerable<EncKeys> keys)
       {
            ...
       }
    }
    public static class DbSerializerHandler
    {
        public static Int64 SerializeFileId(IEnumerable<FileIdSeq> seq)
        {
            ...
        }
    }
