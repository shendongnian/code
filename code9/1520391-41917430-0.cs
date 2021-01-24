    using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
    {
        // Convert c to string, then write it
        writer.Write(c.ToString());
        // Or, using String.Format()
        // writer.Write(String.Format('{0}', c));
    }
