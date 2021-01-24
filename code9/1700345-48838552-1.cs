    // Wherever you get your XML from.
    // You can also use a TextReader object,
    // which means either a StreamReader or StringReader
    // so you can use strings as well.
    using(Stream xmlFile = File.OpenRead(""))
    {
        // Create a new XmlSerializer that deserializes
        // instances of the Race class from XML.
        XmlSerializer serializer = new XmlSerializer(typeof(Race));
        Race race = (Race)serializer.Deserialize(xmlFile);
        // Tada!
        // You now have all of your data in
        // a normal C# object.
        foreach(Vector3 vector in race.Checkpoints.Vectors) 
        {
            Console.WriteLine("X: {0} Y: {1} Z: {2}", vector.X, vector.Y, vector.Z);
        }
    }
