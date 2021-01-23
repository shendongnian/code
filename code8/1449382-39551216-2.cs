    public class Card : MonoBehaviour
    {
        Text topText;
        public Awake()
        {
            topText = GameObject.FindGameObjectWithTag("topText").GetComponent<Text>();
        }
    }
