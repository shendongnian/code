    // psuedo-code
    byte[] serializedObj = DoSerialization(Person);    // we see length on an array
    
    using (var writer = new StreamWriter(stream)) {
        writer.Write(serializedObj.Length);
        stream.Write(serializedObj);
    }
