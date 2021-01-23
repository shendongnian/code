    public class Buttontextchange : MonoBehaviour 
    {
        public void clicked(Gameobject buttonObj)
        {
            Debug.Log("Button Buy Clicked!");
            Text text = buttonObj.GetComponentInChildren<Text>(true);
            if(text != null){
                textRef.text = "i am a button!";´
            }
            Image image = buttonObj.GetComponent<Image>();
            if(image != null){
                image.color = newColor; 
            }
        }
    }
