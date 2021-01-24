    var valuesToReturn = new List<string>();
    valuesToReturn.Add("test01");
    var res = new HttpResponseMessage()
    {
        Content = new StringContent(JsonConvert.SerializeObject(valuesToReturn), Encoding.UTF8, "application/json"),
        StatusCode = HttpStatusCode.Redirect
    };
    return res;
