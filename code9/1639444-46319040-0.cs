    public class TimerTest: MonoBehaviour
    {
        Timer timer = new Timer();
    
        void OnDisable()
        {
            timer.Stop();
            timer.Dispose();
        }
    }
