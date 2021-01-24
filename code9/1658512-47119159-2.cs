    public class ReloadTimer : MonoBehaviour
    {
        public static ReloadTimer Instance { set; get; }
        public Image filled;
        public Text text;
        public float coolDownTime = 3;
        public bool isCoolingDown = false;
        void Awake()
        {
            Instance = this;
        }
        void Update()
        {
            if (isCoolingDown == true)
            {
                filled.fillAmount += 1.0f / coolDownTime * Time.deltaTime;
                int percentageInt = Mathf.RoundToInt((filled.fillAmount / coolDownTime) * 10);
                text.text = percentageInt.ToString();
            }
        }
    }
