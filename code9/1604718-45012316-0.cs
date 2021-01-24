    public class QueryHttpBinding : BasicHttpBinding
    {
        public override BindingElementCollection CreateBindingElements()
        {
            var result = base.CreateBindingElements();
            var http = result.Find<HttpTransportBindingElement>();
            if (http != null)
            {
                http.ManualAddressing = true;
            }
            var https = result.Find<HttpsTransportBindingElement>();
            if (https != null)
            {
                https.ManualAddressing = true;
            }
            return result;
        }
    }
