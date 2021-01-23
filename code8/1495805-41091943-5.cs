    public TextExtractionResult Extract(string filePath)
    {
    var parser = new AutoDetectParser();
    var metadata = new Metadata();
    var parseContext = new ParseContext();
    java.lang.Class parserClass = parser.GetType();
    parseContext.set(parserClass, parser);
     
    try
    {
    var file = new File(filePath);
    var url = file.toURI().toURL();
    using (var inputStream = MetadataHelper.getInputStream(url, metadata))
    {
    parser.parse(inputStream, getTransformerHandler(), metadata, parseContext);
    inputStream.close();
    }
     
    return assembleExtractionResult(_outputWriter.toString(), metadata);
    }
    catch (Exception ex)
    {
    throw new ApplicationException("Extraction of text from the file '{0}' failed.".ToFormat(filePath), ex);
    }
    }
