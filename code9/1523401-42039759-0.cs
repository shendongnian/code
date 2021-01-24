    static void Main(string[] args) {
        var xslt = new FileInfo(@"transform.xslt");
        var input = new FileInfo(@"input.xml");
        var output = new FileInfo(@"output.xml");
        var processor = new Processor();
        var compiler = processor.NewXsltCompiler();
        var executable = compiler.Compile(new Uri(xslt.FullName));
        var transformer = executable.Load();
        var serializer = new Serializer();
        using (var writer = new StreamWriter(output.FullName))
        using (var inputStream = input.OpenRead()) {
            serializer.SetOutputWriter(writer);
            transformer.SetInputStream(inputStream, new Uri(Path.GetTempPath()));
            transformer.SetParameter(
                new QName("password"),
                new XdmAtomicValue("secret"));
            transformer.Run(serializer);
        }
