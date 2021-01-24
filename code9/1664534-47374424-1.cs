    public struct CountDownTimer
    {
        private static int sTimerID = 0;
        private MonoBehaviour monoBehaviour;
    
        public int timer { get { return localTimer; } }
        private int localTimer;
    
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
    
        public void Start(int interval, Action<int> tickCallBack, Action<int> finshedCallBack)
        {
            localTimer = interval;
            monoBehaviour.StartCoroutine(beginCountDown(tickCallBack, finshedCallBack));
        }
    
        private IEnumerator beginCountDown(Action<int> tickCallBack, Action<int> finshedCallBack)
        {
            while (localTimer > 0)
            {
                yield return new WaitForSeconds(1.0f);
                localTimer--;
                //Notify tickCallBack in each clock tick
                tickCallBack(localTimer);
            }
    
            //Notify finshedCallBack after timer is done
            finshedCallBack(localID);
        }
    }
