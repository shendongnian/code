       static void Main(string[] args)
        {
            SomeClass[] output;
            var json = "[{\"foo\":\"value\"},{\"bar\":\"value\"},{\"foo\":\"value1\"},{\"foo\":\"value1\"}]";
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                var deserializer = new DataContractJsonSerializer(typeof(SomeClass[]));
                 output = (SomeClass[])deserializer.ReadObject(ms);
            }
            // do something with output
            Console.WriteLine(output.Length);
        }
