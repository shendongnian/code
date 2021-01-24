    string[] parts = new string[]
    {
    	"abcdefg",
    	"Lorem ipsum dolor sit amet, consectetur adipiscing elit.Maecenas viverra turpis mauris, nec aliquet ex sodales in.",
    	"Vivamus et quam felis. Vestibulum sit amet enim augue.",
    	"Sed tincidunt felis nec elit facilisis sagittis.Morbi eleifend feugiat leo, non bibendum dolor faucibus sed."
    };
    MemoryStream stream = new MemoryStream();
    // serialize each string as a couple of size/bytes array.
    BinaryWriter binWriter = new BinaryWriter(stream);
    foreach (var part in parts)
    {
    	var bytes = UTF8Encoding.UTF8.GetBytes(part);
    	binWriter.Write(bytes.Length);
    	binWriter.Write(bytes);
    }
    
    // read the bytes stream: first get the size of the bytes array, then read the bytes array and convert it back to a stream.
    stream.Seek(0, SeekOrigin.Begin);
    BinaryReader reader = new BinaryReader(stream);
    while (stream.Position < stream.Length)
    {
    	int size = reader.ReadInt32();
    	var bytes = reader.ReadBytes(size);
    	var part = UTF8Encoding.UTF8.GetString(bytes);
    	Console.WriteLine(part);
    }
    stream.Close();
    Console.ReadLine();
