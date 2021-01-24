    public class CountdownTimer : MonoBehaviour
    {
        private float seconds;
        [SerializeField]
        private Text timerText;
    
        private void Awake()
        {
            if (!string.isNullOrEmpty(timerText))
            {
                seconds = float.Parse(timerText.text);          
            }
        }
        // Yep, Event Functions can be private and Unity will `call` them anyways
        private void Update() 
        {
            seconds -= Time.deltaTime;
            if (timerText != null)
            {
                timerText.text = Mathf.Round(seconds).ToString();
                Debug.Log (Mathf.Round(seconds));
            }
        }
    }
