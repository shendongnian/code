    internal class TestClass
    {
        public void Test()
        {
            var writeStream = new MemoryStream();
            long beginLength = 0;
            long endLength = 0;
            EventHandler begin = (o, e) => { beginLength = writeStream.Length; Console.WriteLine(string.Format("Begin serialization of Data, writeStream.Length = {0}", writeStream.Length)); };
            EventHandler end = (o, e) => { endLength = writeStream.Length;  Console.WriteLine(string.Format("End serialization of Data, writeStream.Length = {0}", writeStream.Length)); };
            StreamObject.OnDataReadBegin += begin;
            StreamObject.OnDataReadEnd += end;
            try
            {
                int length = 1000000;
                var inputStream = new MemoryStream();
                for (int i = 0; i < length; i++)
                {
                    inputStream.WriteByte(unchecked((byte)i));
                }
                inputStream.Position = 0;
                var streamObject = new StreamObject(inputStream);
                Serializer.Serialize(writeStream, streamObject);
                var data = writeStream.ToArray();
                StreamObject newStreamObject;
                using (var s = new MemoryStream(data))
                {
                    newStreamObject = Serializer.Deserialize<StreamObject>(s);
                }
                if (beginLength >= endLength)
                {
                    throw new InvalidOperationException("inputStream was completely buffered before writing to writeStream");
                }
                inputStream.Position = 0;
                newStreamObject.StreamProperty.Position = 0;
                if (!inputStream.AsEnumerable().SequenceEqual(newStreamObject.StreamProperty.AsEnumerable()))
                {
                    throw new InvalidOperationException("!inputStream.AsEnumerable().SequenceEqual(newStreamObject.StreamProperty.AsEnumerable())");
                }
                else
                {
                    Console.WriteLine("Streams identical.");
                }
            }
            finally
            {
                StreamObject.OnDataReadBegin -= begin;
                StreamObject.OnDataReadEnd -= end;
            }
        }
    }
    public static class StreamExtensions
    {
        public static IEnumerable<byte> AsEnumerable(this Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException();
            int b;
            while ((b = stream.ReadByte()) != -1)
                yield return checked((byte)b);
        }
    }
