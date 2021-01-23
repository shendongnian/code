    class WCFErrorResponseTranslator
    {
        ServiceResponseModel TranslateWCFException (Exception ex)
        {
            if (ex.GetType() == typeOf(TimeoutException)) { return ServiceResponseModel.TimeOut; }
            /// etc
        }
    }
