    public int? Key
    {
        get
        {
            byte[] bytes = new byte[KEY_BYTES];
            fs.Seek((KEY_BYTES + DATA_BYTES) * Index, SeekOrigin.Begin);
