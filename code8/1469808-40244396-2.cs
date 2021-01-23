    Root root;
    using (var stream = new FileStream("test.xml", FileMode.Open))
        root = (Root)xs.Deserialize(stream);
    Console.WriteLine(root.A);
    Console.WriteLine(root.B);
    foreach (var pair in root.Dict)
        Console.WriteLine(pair);
