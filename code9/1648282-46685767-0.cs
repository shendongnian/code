    public static async Task getResponseFromUrlAsync<T>(T payload, string url, Action<string> onSuccess, Action<string> onFailure)
    {
        string contentType = "application/json";
        httpClient = new HttpClient();
        httpClient.Timeout = TimeSpan.FromMinutes(30);
        HttpRequestMessage requestMsg = new HttpRequestMessage();
        requestMsg.RequestUri = new Uri(NetworkCallUrls.baseUri + url);
        Utils.debugLog("Url", NetworkCallUrls.baseUri + url);
        string auth = "Bearer " + Objects.GlobalVars.GetValue<string>("access_token"); // //"x1VwaR1otS66ZCTlgtv3X9aaSNpDOn"; //
        httpClient.DefaultRequestHeaders.Add("Authorization", auth);
        requestMsg.Method = HttpMethod.Post;
        requestMsg.Content = new StringContent(
                       Utils.stringifyData(payload),
                       Encoding.UTF8,
                       contentType);
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header
        await makeNetworkCallCheckResponseStatusAndExecuteCorrospondingAction(requestMsg, onSuccess, onFailure, progressBarStatus)
            .ConfigureAwait(false);
    }
    internal static void disposeConnection(HttpClient httpClient)
    {
        httpClient.Dispose();
        httpClient = null;
    }
    private static async Task makeNetworkCallCheckResponseStatusAndExecuteCorrospondingAction(
        HttpRequestMessage requestMsg, Action<string> onSuccess,
        Action<string> onFailure, Action<bool> progressBarStatus)
    {
        Utils.debugLog("IN MAKE NETWORK CALL 1");
        HttpResponseMessage response = await httpClient.SendAsync(requestMsg).ConfigureAwait(false);
        Utils.debugLog("IN MAKE NETWORK CALL 2");
        ResponseStatus responseStatus = checkResponseStatusAndExecuteActionAccordinglyAsync(response);
        Utils.debugLog("IN MAKE NETWORK CALL 3");
        if (responseStatus.isSuccess)
        {
            Utils.debugLog("IN MAKE NETWORK CALL 4");
            string responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            Utils.debugLog("IN MAKE NETWORK CALL 5");
            onSuccess(responseString);
            Utils.debugLog("IN MAKE NETWORK CALL 6");
        }
        else
        {
            Utils.debugLog("IN MAKE NETWORK CALL 7");
            onFailure(responseStatus.failureResponse);
            Utils.debugLog("IN MAKE NETWORK CALL 8");
        }
        Utils.debugLog("IN MAKE NETWORK CALL 9");
        disposeConnection(httpClient);
        Utils.debugLog("IN MAKE NETWORK CALL 10");
    }
