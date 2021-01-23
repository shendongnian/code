    class WCFErrorResponseTranslator
    {
        ServiceResponse TranslateWCFException (Exception ex)
        {
            if (ex.GetType() == typeOf(TimeoutException)) { return ServiceResponse.TimeOut; }
            /// etc
        }
    }
