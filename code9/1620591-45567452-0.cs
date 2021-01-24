    public class CustomXmlWriterSettings : XmlWriterSettings
    {
       public CustomXmlWriterSettings()
       {
         Indent = true;
         IndentChars = ("\t");
         OmitXmlDeclaration = true;
       }
       public CustomXmlWriterSettings(bool in, string ch, bool de)
       {
         Indent = in;
         IndentChars = ch;
         OmitXmlDeclaration = de;
       }
    }
