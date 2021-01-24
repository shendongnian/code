    **[WebGet(ResponseFormat = WebMessageFormat.Xml)]**
        public int getSuma(int numero1, int numero2)
            {
                WebOperationContext.Current.OutgoingResponse.ContentType =  "text/xml";
                return numero1 + numero2;
            }
