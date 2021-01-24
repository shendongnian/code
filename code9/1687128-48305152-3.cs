    public static void Main()
    {
        var axe = Weapon.Axe;
        var savedContent = new MemoryStream();
        var formatter = new BinaryFormatter();
        formatter.Serialize(savedContent, axe);
        savedContent.Position = 0;
        var deserializedAxe = (Weapon)formatter.Deserialize(savedContent);
        Console.WriteLine(ReferenceEquals(axe, deserializedAxe)); // prints True
    }
