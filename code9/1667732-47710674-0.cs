    public JToken Create(ObjCode objcode, object parameters) {
        VerifySignedIn();
        string[] p = parameterObjectToStringArray(parameters, "sessionID=" + SessionID);
        JToken json = client.DoPost(string.Format("/{0}", objcode), p);
        return json;
    }
