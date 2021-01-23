    var responseString = ((HttpResponseMessage)response).Content.ReadAsStringAsync().Result;
    if(response.ToLower().Contains("no values found")) {
        //do something here like returning an empty model
    }
    else
    {
        returnValue = JsonConvert.DeserializeObject<T>(responseString);
    }
