    using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
    {
        writer.Write(c);
        // Unless you want 'c' to be a string, then use
        writer.Write(c.ToString());
        // You can also use StringFormat
        writer.Write(string.Format("{0}", c));
    }
