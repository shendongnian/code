    HttpClientHandler SetServicePointOptions(HttpClientHandler handler)
    {
        var field = handler.GetType().GetField("_startRequest", BindingFlags.NonPublic| BindingFlags.Instance); // Fieldname has a _ due to being private
        var startRequest = (Action<object>)field.GetValue(handler);
        Action<object> newStartRequest = obj =>
        {
            var webReqField = obj.GetType().GetField("webRequest", BindingFlags.NonPublic | BindingFlags.Instance);
            var webRequest = webReqField.GetValue(obj) as HttpWebRequest;
            webRequest.ServicePoint.BindIPEndPointDelegate = new BindIPEndPoint(BindIPEndPointCallback);
            
            startRequest(obj); //call original action
        };
        field.SetValue(handler, newStartRequest); //replace original 'startRequest' with the one above
        return handler;
    }
