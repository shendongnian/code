    namespace ABELSoft.Dental.Interface.Helper
    {
        public class RtfToText
        {
            public static string convert(string rtfText)
            {
                string _text;
                var documentServer = new RichEditDocumentServer();
                documentServer.Document.RtfText = rtfText;
                _text = documentServer.Document.Text;
                return _text;
            }
        }
    }
