    namespace Program.userws  //note this namespace must match the namespace 
                              //that the webservice is declared in (in auto-generated code)
    {
        partial class UserWebService
        {
            protected override XmlReader GetReaderForMessage(SoapClientMessage message, int bufferSize)
            {
                return new EnumSafeXmlReader(message.Stream);
            }
        }
    }
