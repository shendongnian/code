    public void Get(string Url, CallbackAjaxFinished cbAjaxFinished, IJsonSerializer<T> serializer = null)
    {
        // whenever you call ConvertAndCallback
        ConvertAndCallback(param1, param2, serializer); // just pass the same serializer here
    }
