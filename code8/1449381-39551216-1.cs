    public class Card : MonoBehaviour
    {
        Text topText;
       //Bad, because  `MonoBehaviour` is inherited
        public Card()
        {
            topText = GameObject.FindGameObjectWithTag("topText").GetComponent<Text>();
        }
    }
