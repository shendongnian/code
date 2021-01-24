    private byte[] byteArray;
    public byte[] ByteArray
    {
        get { return this.byteArray; } 
        set
        {
            this.SetByteArray(value);
        }
    }
    
    private void SetByteArray(byte[] value)
    {
        if (value.Length % 2 == 0)
        {
            this.byteArray = value;
        }
        else
        {
            var x = new List<byte>(value);
            x.Add(0);
            this.byteArray = x.ToArray();
        }
    }
