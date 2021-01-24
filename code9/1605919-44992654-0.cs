    //Scale Min and max
    public float scaleMin = 0;
    public float scaleMax = 100f;
    
    //Accelerometer min/max. Find this with Debug.Log(Input.acceleration.y);
    public float accelYMin = -10;
    public float accelYMax = 10;
    
    void Update()
    {
        float accelY = Input.acceleration.y;
        float scaledVal = mapValue(accelY, accelYMin, accelYMax, scaleMin, scaleMax);
        transform.localScale = new Vector3(0, scaledVal, 0);
    }
    
    float mapValue(float mainValue, float inValueMin, float inValueMax, float outValueMin, float outValueMax)
    {
        return (mainValue - inValueMin) * (outValueMax - outValueMin) / (inValueMax - inValueMin) + outValueMin;
    }
