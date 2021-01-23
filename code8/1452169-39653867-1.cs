    public class Buttontextchange : MonoBehaviour 
    {
        public void clicked(Text textRef)
        {
            Debug.Log("Button Buy Clicked!");
            textRef.text = "i am a button!";
        }
    }
