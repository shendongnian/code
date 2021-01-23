    public class Card
    {
        Text topText;
        //Constructor
       //Correct, because no `MonoBehaviour` inherited
        public Card()
        {
            topText = GameObject.FindGameObjectWithTag("topText").GetComponent<Text>();
        }
    }
