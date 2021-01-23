    class WCFErrorResponseTranslator
    {
        ServiceResponse TranslateWCFException (Exception ex)
        {
            if (ex.typeOf(TimeoutException)) { return ServiceResponse.TimeOut; }
            /// etc
        }
    }
