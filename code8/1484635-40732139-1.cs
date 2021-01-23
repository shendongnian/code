    private List<Data> dataList = new List<Data>();
    Thread samplingThread;
    const float samplingRate = 2f; // sample rate in Hz
    Vector3 posInThread;
    float TimetimeInThread;
    private System.Object threadLocker = new System.Object();
    void OnEnable()
    {
        startSampling();
    }
    void startSampling()
    {
        samplingThread = new Thread(OnSamplingData);
        samplingThread.Start();
    }
    void Update()
    {
        lock (threadLocker)
        {
            //Update this values to be used in another Thread
            posInThread = transform.position;
            TimetimeInThread = Time.time;
        }
    }
    void OnSamplingData()
    {
        long oldTime = DateTime.Now.Ticks;
        long currentTime = oldTime;
        const float waitTime = 1f / samplingRate;
        float counter;
        while (true)
        {
            currentTime = DateTime.Now.Ticks;
            counter = (float)TimeSpan.FromTicks(currentTime - oldTime).TotalSeconds;
            if (counter >= waitTime)
            {
                //Debug.Log("counter: " + counter + "  waitTime: " + waitTime);
                oldTime = currentTime; //Store current Time
                SampleNow();
            }
            Thread.Sleep(0); //Make sure Unity does not freeze
        }
    }
    public void SampleNow()
    {
        Debug.Log("Called");
        lock (threadLocker)
        {
            dataList.Add(new Data(TimetimeInThread, posInThread.x, posInThread.y, posInThread.z));
        }
    }
    void OnDisable()
    {
        if (samplingThread != null && samplingThread.IsAlive)
        {
            samplingThread.Abort();
        }
        samplingThread.Join(); //Wait for Thread to finish then exit
    }
