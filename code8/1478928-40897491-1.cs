    string code;
    using (var provider = CodeDomProvider.CreateProvider("CSharp"))
    using (var stream = new MemoryStream())
    using (var writer = new StreamWriter(stream))
    using (var reader = new StreamReader(stream))
    {
        provider.GenerateCodeFromType(testClass, writer, new CodeGeneratorOptions() { BracingStyle = "C" });
        writer.Flush();
        stream.Position = 0;
        code = reader.ReadToEnd();
    }
