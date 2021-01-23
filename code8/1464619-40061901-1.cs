    public class MainMenu: MonoBehaviour
    {
    
        Timer timerScript;
        void Start()
        {
            timerScript = GameObject.Find("GameObjectTimerIsAttachedTo").GetComponent<Timer>();
            timerScript.DestroyTimer();
            
            //Or option 2
            timerScript.StopAndResetTimer()
        }
    }
