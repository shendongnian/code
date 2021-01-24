    public class GameController : MonoBehaviour {
    
    public class Timer
    {
        int elapsedTime;
        int pausedTime;
    
        bool isCounting;
        public void Start()
        {
            int startTime = DateTime.Now.Millisecond;
            while(isCounting)
            {
                elapsedTime = DateTime.Now.Millisecond - startTime;
            }
        }
    }
    
    private void Update()
    {
        //Debug logging of the timer functions
        if(startButton.CompareTag("Clicked"))
        {
            Timer.Start();
        }
    
    }
    }
