    private  int _randomFoo;
    private System.Timers.Timer _t = new System.Timers.Timer();
    
    void Awake()
    {
        UnityThread.initUnityThread();
    }
    
    // Use this for initialization
    void Start()
    {
        _t.Interval = 1000;
        _t.Elapsed += TimerUpdate;
        _t.Start();
    }
    
    
    public void TimerUpdate(object sender, System.Timers.ElapsedEventArgs e)
    {
        UnityThread.executeInUpdate(() =>
        {
            _randomFoo = Random.Range(0, 20);
        });
    }
