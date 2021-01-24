    string id = "";
    DateTime from = new DateTime();
    DateTime to = new DateTime();
    
    StartCoroutine(GetMeasurements(id, from, to, (measurementResult) =>
    {
        string measurement = measurementResult;
    
        //Do something with measurement
        UnityEngine.Debug.Log(measurement);
    
    }));
