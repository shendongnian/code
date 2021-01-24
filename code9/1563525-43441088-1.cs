        public void Utf8JsonCharSerializeAndDeserializeShouldEqualFixed()
        {
            Utf8JsonCharSerializeAndDeserializeShouldEqualFixed((char)56256);
        }
        public void Utf8JsonCharSerializeAndDeserializeShouldEqualFixed(char utfChar)
        {
            byte[] data;
            using (MemoryStream ms = new MemoryStream())
            {
                using (StreamWriter writer = new StreamWriter(ms, new UTF8Encoding(true, true), 1024))
                {
                    var serializer = new JsonSerializer();
                    serializer.Serialize(writer, utfChar.ToByteArrayWithoutEncoding());
                }
                data = ms.ToArray();
            }
            using (MemoryStream ms = new MemoryStream(data))
            {
                using (StreamReader reader = new StreamReader(ms, true))
                {
                    using (JsonTextReader jsonReader = new JsonTextReader(reader))
                    {
                        var serializer = new JsonSerializer();
                        char deserializedChar = serializer.Deserialize<byte[]>(jsonReader).ToCharWithoutEncoding();
                        //Console.WriteLine(string.Format("{0}, {1}", utfChar, deserializedChar));
                        Assert.AreEqual(utfChar, deserializedChar);
                        Assert.AreEqual((int)utfChar, (int)deserializedChar);
                    }
                }
            }
        }
