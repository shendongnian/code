    private static void Main(string[] args)
            {
                var foo = new Foo("boo");
                var serializer = new DataContractJsonSerializer(typeof(Foo));
                string str;
                using (var stream = new MemoryStream())
                {
                    serializer.WriteObject(stream, foo);
                    str = Encoding.Default.GetString(stream.ToArray());
                }
    
                Console.WriteLine(str);
                Foo loadedFoo;
                using (var stream = new MemoryStream(Encoding.Default.GetBytes(str)))
                {
                    loadedFoo = serializer.ReadObject(stream) as Foo;
                }
                Console.WriteLine(loadedFoo.Boo);
                Console.ReadLine();
            }
