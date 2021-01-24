    // notice we are creating a new file here
    using (var writer = new StreamWriter(path, false, Encoding.UTF8))
    {
        // Add a BOM in the beginning of the file
        var preamble = Encoding.UTF8.GetPreamble();
        writer.BaseStream.Write(preamble, 0, preamble.Length);
        
        // write data...
        writer.WriteLine(string.Join(",", "Danhostel Rønne", "Arsenalvej 12 3700 Rønne"));
    }
    
    // when you write the same file again, you don't need to append the BOM again
    using (var writer = new StreamWriter(path, true, Encoding.UTF8))
    {
        // write more data...
        writer.WriteLine(string.Join(",", "Danhostel Rønne", "Arsenalvej 12 3700 Rønne"));
    }
