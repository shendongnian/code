     public ConversionResult ConvertToPDF(string documentName, Stream docContent, double timeoutMS)
    {
        /** Your code **/
        return new ConversionResult() 
            {
            MemoryStream = memoryStream,
            ConversionException = conversionException
            };
    }
    class ConversionResult {
        MemoryStream MemoryStream {get;set;}
        ExceptionDispatchInfo ConversionException {get;set;}
    }
