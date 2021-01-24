    public void PerformMyAwesomeRequest(string myToken, Action<MyCustomType> onSuccess, Action<ErrorMessageCustomType> onError) {
        var response = client.Execute(request).Content;
        var statusCode = FetchStatusCode(response);
        if (statusCode != 0) {
            onSuccess(JsonConvert.DeserializeObject<MyCustomType>(response));
        } else {
            onError(JsonConvert.DeserializeObject<ErrorMessageCustomType>(response));
        }
    }
