        public class ExtEntity<T> : TableEntity where T : new()
    {
        private const int MAX_BYTES_PER_ARR = 65500; // don't use full 64k to avoid any weird edge case
        // Serialized in DB and deserialized for callers
        public Byte[] A0 { get; set; }
        public Byte[] A1 { get; set; }
        public Byte[] A2 { get; set; }
        public Byte[] A3 { get; set; }
        public Byte[] A4 { get; set; }
        public Byte[] A5 { get; set; }
        public Byte[] A6 { get; set; }
        public Byte[] A7 { get; set; }
        public Byte[] A8 { get; set; }
        public Byte[] A9 { get; set; }
        public Byte[] A10 { get; set; }
        public Byte[] A11 { get; set; }
        public Byte[] A12 { get; set; }
        public Byte[] A13 { get; set; }
        public Byte[] A14 { get; set; }
        public Byte[] A15 { get; set; }
        private T value;
        public T Value
        {
            // Accessors automatically serialize and deserialize T value
            get
            {
                // ASSUMES that value will never change after first time deserialized!
                if (this.value == null)
                {
                    int n = 0;
                    using (var memStream = new MemoryStream())
                    {
                        while (true)
                        {
                            string propName = "A" + n++;
                            PropertyInfo prop = this.GetType().GetProperty(propName);
                            byte[] arr = (byte[])prop.GetValue(this);
                            if (arr == null || arr.Length == 0)
                            {
                                break;
                            }
                            memStream.Write(arr, 0, arr.Length);
                        }
                        memStream.Seek(0, SeekOrigin.Begin);
                        var binForm = new BinaryFormatter();
                        this.value = (T)binForm.Deserialize(memStream);
                    }
                }
                return this.value;
            }
            set
            {
                // First, ensure the type is serializable.
                if (!typeof(T).IsSerializable && !(typeof(ISerializable).IsAssignableFrom(typeof(T))))
                    throw new InvalidOperationException("ExtEntity<T>.get_Value Exception: A serializable Type is required.");
                // Assign the value
                this.value = value;
                // Then searialize it for Table Storage use
                BinaryFormatter bf = new BinaryFormatter();
                using (var memStream = new MemoryStream())
                {
                    // Serialize into memory stream, then seek back to origin
                    bf.Serialize(memStream, this.value);
                    memStream.Seek(0, SeekOrigin.Begin);
                    // Chunk data from memory stream into stored properties
                    int bytesRemaining = (int)memStream.Length;
                    int n = 0;
                    while (bytesRemaining > 0)
                    {
                        if (n > 15)
                        {
                            throw new ApplicationException("ExtEntity<T>.set_Value Exception: Data is too large.");
                        }
                        int numToRead = Math.Min(bytesRemaining, ExtEntity<T>.MAX_BYTES_PER_ARR);
                        byte[] arr = new byte[numToRead];
                        int numRead = memStream.Read(arr, 0, numToRead);
                        if (numRead != numToRead)
                        {
                            throw new ApplicationException("ExtEntity<T>.set_Value Exception: Unexpected number of bytes returned.");
                        }
                        string propName = "A" + n++;
                        PropertyInfo prop = this.GetType().GetProperty(propName);
                        prop.SetValue(this, arr);
                        bytesRemaining -= numRead;
                    }
                }
            }
        }
    }
