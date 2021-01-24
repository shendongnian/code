    public class MuteButton: MonoBehaviour
    {
        Graphic myGraphic;
        private void Awake() {
            myGraphic = GetComponent<Graphic>();
        }
        public void OnClick() {
            MuteScript.ToggleMute(myGraphic);
            //I assume you want to do something like change the colour of the button when
            //the player toggles it. Passing the Graphic to the MuteScript is the easiest 
            //way of doing this. If you really want to keep your code clean, though,
            //I recommend expanding the MuteButton class with methods to take care of
            //the UI side of things.
        }
    }
