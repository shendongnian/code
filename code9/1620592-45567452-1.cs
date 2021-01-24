    public class CustomXmlWriterSettings : YourXmlWriterSettings // Use your own class as XmlWriterSettings is sealed and therefore uninheritable
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
