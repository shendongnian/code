    using (var scope = new OperationContextScope(client.InnerChannel))
    {
        var hrmp = new HttpRequestMessageProperty();
        hrmp.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(mUserName + ":" + mPassword));
        OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = hrmp;
        int result = client.AddOrUpdate(obj);
    }
