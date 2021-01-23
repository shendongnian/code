    var responseMessage = await httpClient.GetAsync("http://115.248.50.60/registration/Main.jsp?wispId=1&nasId=00:15:17:c8:09:b1");
    IEnumerable<string> values;
    var coockieHeader = string.Empty;
    if (responseMessage.Headers.TryGetValues("set-cookie", out values))
    {
        coockieHeader = string.Join(string.Empty, values);
    }
