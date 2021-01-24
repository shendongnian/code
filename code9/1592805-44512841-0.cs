    public class CountdownTimer : MonoBehaviour
    {
        float seconds;
        public Text timerText;
    
        public void Update()
        {
            seconds -= Time.deltaTime;
            if (timerText != null)
            {
                timerText.text = Mathf.Round(seconds).ToString();
                Debug.Log (Mathf.Round(seconds));
            }
        }
    }
