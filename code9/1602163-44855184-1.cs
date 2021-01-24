    void Main()
    {
        // Checking the child's default value
        Child c1 = Deserialize<Child>("<Child/>");
        Console.WriteLine(c1.X); // it will print 10.
        Child c2 = Deserialize<Child>("<Child X='30'/>");
        Console.WriteLine(c2.X); // it will print 30.
        
        // Checking the parent's default value
        Parent p1 = Deserialize<Parent>("<Parent></Parent>");
        Console.WriteLine(p1.C.X); // it will print 5.
        Parent p2 = Deserialize<Parent>("<Parent><C Y='1000'/></Parent>");
        Console.WriteLine(p2.C.X); // it will print 5.
        Parent p3 = Deserialize<Parent>("<Parent><C X='20' Y='1000'/></Parent>");
        Console.WriteLine(p3.C.X); // it will print 20.
    }
    T Deserialize<T>(string xmlText)
    {
        using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(xmlText)))
        {
            using (var reader = XmlDictionaryReader.CreateTextReader(memoryStream, Encoding.UTF8, XmlDictionaryReaderQuotas.Max, null))
            {
                var xmlDeserializer = new XmlSerializer(typeof(T));
                return (T)xmlDeserializer.Deserialize(reader);
            }
        }
    }
