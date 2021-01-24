    public struct CountDownTimer
    {
        private static int sTimerID = 0;
        private MonoBehaviour monoBehaviour;
    
        public float timer { get { return localTimer; } }
        private float localTimer;
    
        public int timerID { get { return localID; } }
        private int localID;
    
        public CountDownTimer(MonoBehaviour monoBehaviour)
        {
            this.monoBehaviour = monoBehaviour;
            localTimer = 0;
    
            //Assign timer ID
            sTimerID++;
            localID = sTimerID;
        }
    
        public void Start(int interval, Action<float, int> tickCallBack, Action<int> finshedCallBack)
        {
            localTimer = interval;
            monoBehaviour.StartCoroutine(beginCountDown(tickCallBack, finshedCallBack));
        }
    
        private IEnumerator beginCountDown(Action<float, int> tickCallBack, Action<int> finshedCallBack)
        {
            while (localTimer > 0)
            {
                localTimer -= Time.deltaTime;
                //Notify tickCallBack in each clock tick
                tickCallBack(localTimer, localID);
                yield return null;
            }
    
            //Notify finshedCallBack after timer is done
            finshedCallBack(localID);
        }
    }
