    using Newtonsoft.Json;
    private IEnumerator TestRequest()
    {
        var jsonObject = new
        {
            fare_id = "abcd",
            product_id = "a1111c8c-c720-46c3-8534-2fcdd730040d",
            start_latitude = 37.761492f,
            start_longitude = -122.42394f,
            end_latitude = 37.775393f,
            end_longitude = -122.417546f,
        };
        MemoryStream binaryJson = new MemoryStream();
        using (StreamWriter writer = new StreamWriter(binaryJson))
            new JsonSerializer().Serialize(writer, jsonObject);
        using (UnityWebRequest uweb = UnityWebRequest.Post("https://sandbox-api.uber.com/v1.2/requests"))
        {
            uweb.SetRequestHeader("Authorization", "Bearer " + sToken);
            uweb.SetRequestHeader("Content-Type", "application/json");
            UploadHandlerRaw uploadHandler = new UploadHandlerRaw(binaryJson.ToArray());
            uweb.uploadHandler = uploadHandler;
            yield return uweb.Send();
            if(uweb.isError)
                Debug.Log(uweb.error);
            else
                Debug.Log(uweb.downloadHandler.text);
        }
    }
