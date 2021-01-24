    namespace SoapExentender
    {
        class WebServiceSOAPExtension : SoapExtension
        {
            Stream oldStream;
            Stream newStream;
            string filename;
        public override Stream ChainStream(Stream stream)
        {
            oldStream = stream;
            newStream = new MemoryStream();
            return newStream;
        }
        // When the SOAP extension is accessed for the first time, the XML Web service method it is applied to is accessed to store the file name passed in,
        //using the corresponding SoapExtensionAttribute.    
        public override object GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute)
        {
            return null;
        }
        // The SOAP extension was configured to run using a configuration file instead of an attribute applied to a specific XML Web service method.
        public override object GetInitializer(Type WebServiceType)
        {
            return null;
        }
        // Receive the file name stored by GetInitializer and store it in a member variable for this specific instance.
        public override void Initialize(object initializer)
        {
            filename = ConfigurationManager.AppSettings["STOFacturacionDLL"].ToString();
        }
        //  If the SoapMessageStage is such that the SoapRequest or SoapResponse is still in the SOAP format to be sent or received, save it out to a file.
        public override void ProcessMessage(SoapMessage message)
        {
            switch (message.Stage)
            {
                case SoapMessageStage.BeforeSerialize:
                    break;
                case SoapMessageStage.AfterSerialize: //el xml serializado de salida
                    WriteOutput((SoapClientMessage)message);
                    break;
                case SoapMessageStage.BeforeDeserialize:
                    WriteInput((SoapClientMessage)message);
                    break;
                case SoapMessageStage.AfterDeserialize:
                    break;
                default:
                    throw new Exception("Stage inválido");
            }
        }
        // Write the contents of the outgoing SOAP message to the log file.
        public void WriteOutput(SoapClientMessage message)
        {
            newStream.Position = 0;
            FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write);
            StreamWriter myStreamWriter = new StreamWriter(fs);
            myStreamWriter.WriteLine("================================== Fecha del request: " + DateTime.Now);
            // Print to the log file the request header field for SoapAction header.
            myStreamWriter.WriteLine(@"La acción SOAP del 'header' Http request  es: " + message.Action);
            // Print to the log file the method invoked by the client.
            myStreamWriter.WriteLine("El metodo llamado fue: " + message.MethodInfo.Name);
            // Print to the log file if the method invoked is OneWay.
            if (message.OneWay)
                myStreamWriter.WriteLine("El cliente no espera a que se termine el proceso (no es de un solo sentido)");
            else
                myStreamWriter.WriteLine("El cliente espera a que se termine el proceso");
            // Print to the log file the URL of the site that provides implementation of the method.
            myStreamWriter.WriteLine("La URL solicitada fue: " + message.Url);
            myStreamWriter.WriteLine("el contenido del request/response del ---- <soap:envelope> ---- es : ");
            myStreamWriter.Flush();
            Copy(newStream, fs);
            myStreamWriter.Close();
            //replace custom text
            string stringRequest = "";
            try
            {
                newStream.Position = 0;
                MemoryStream RequestStream = new MemoryStream();
                Copy(newStream, RequestStream);
                RequestStream.Position = 0;
                byte[] bytesRequestStream = ReadFully(RequestStream);
                stringRequest = System.Text.Encoding.UTF8.GetString(bytesRequestStream);
                stringRequest = replaceText(stringRequest, "<ReimprimirReferencia", "<thepanch:ReimprimirReferencia");
                int i = 0;
            }
            catch (Exception exc) { }
            newStream.Position = 0;
            //replace the original stream, with the custom stream
            Copy(ConvertStringToStream(stringRequest), oldStream);
        }
        private string replaceText(string MainString, string SearchString, string ReplaceWith)
        {
            MainString = MainString.Replace(SearchString, ReplaceWith);
            return MainString;
        }
        private MemoryStream ConvertStringToStream(string RequestString)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(RequestString);
            MemoryStream stream = new MemoryStream(byteArray);
            stream.Position = 0;
            return stream;
        }
        private byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
        public void WriteInput(SoapMessage message)
        {
            Copy(oldStream, newStream);
            FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write);
            StreamWriter w = new StreamWriter(fs);
            string soapString = (message is SoapServerMessage) ? "SoapRequest" : "SoapResponse";
            w.WriteLine("----------" + soapString + " at " + DateTime.Now);
            w.Flush();
            newStream.Position = 0;
            Copy(newStream, fs);
            w.Close();
            newStream.Position = 0;
        }
        void Copy(Stream from, Stream to)
        {
            TextReader reader = new StreamReader(from);
            TextWriter writer = new StreamWriter(to);
            writer.WriteLine(reader.ReadToEnd());
            writer.Flush();
        }
    }
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class WebServiceSOAPExtensionAttribute : SoapExtensionAttribute
    {
        private int priority;
        public override Type ExtensionType
        {
            get { return typeof(WebServiceSOAPExtension); }
        }
        public override int Priority
        {
            get { return priority; }
            set { priority = value; }
        }
    }
