    public static void Main(string[] args)
        {
            foreach(var d in DividedStream)
                Console.WriteLine(Encoding.UTF8.GetString(d.ToArray()));
            Console.WriteLine("new version:\n");
            Console.WriteLine(string.Concat(ByteStream.Select(x => x.Equals(0) ? Environment.NewLine : Encoding.UTF8.GetString(new[] {x}))));
            Console.ReadKey();
        }
