    try
    {
       //OutputFormatting is a public enum from the Schematron library. Valid values include boolean, default, Log, simple and XML.
       OutputFormatting format = OutputFormatting.XML;
       var bookValidator = new Validator(format);
       bookValidator.AddSchema("book.xsd");
       bookValidator.Validate("book.xml");
    }
    catch (Exception ex)
    {
       //ex.Message will now be in XML format and can be processed however I want!
       Console.WriteLine(ex.Message);
    }
