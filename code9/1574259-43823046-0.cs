    [Serializable]
    public class UberJson
    {
        public string fare_id;
        public string product_id;
        public double start_latitude;
        public double start_longitude;
        public double end_latitude;
        public double end_longitude;
    }
    void Start()
    {
        postJson();
    }
    string createUberJson()
    {
        UberJson uberJson = new UberJson();
        uberJson.fare_id = "abcd";
        uberJson.product_id = "a1111c8c-c720-46c3-8534-2fcdd730040d";
        uberJson.start_latitude = 37.761492f;
        uberJson.start_longitude = -122.42394f;
        uberJson.end_latitude = 37.775393f;
        uberJson.end_longitude = -122.417546f;
        //Convert to Json
        return JsonUtility.ToJson(uberJson);
    }
    void postJson()
    {
        string URL = "https://sandbox-api.uber.com/v1.2/requests";
        //string json = "{ \"fare_id\": \"abcd\", \"product_id\": \"a1111c8c-c720-46c3-8534-2fcdd730040d\", \"start_latitude\": 37.761492, \"start_longitude\": -122.423941, \"end_latitude\": 37.775393, \"end_longitude\": -122.417546 }";
        string json = createUberJson();
        string sToken = "";
        //Set the Headers
        UnityWebRequest uwrq = UnityWebRequest.Post(URL, json);
        uwrq.SetRequestHeader("Content-Type", "application/json");
        uwrq.SetRequestHeader("Authorization", "Bearer " + sToken);
        StartCoroutine(WaitForRequest(uwrq));
    }
    IEnumerator WaitForRequest(UnityWebRequest uwrq)
    {
        //Make the request
        yield return uwrq.Send();
        if (String.IsNullOrEmpty(null))
        {
            Debug.Log(uwrq.downloadHandler.text);
        }
        else
        {
            Debug.Log("Error while rececing: " + uwrq.error);
        }
    }
