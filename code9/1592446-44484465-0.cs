    public class MyClass : MonoBehaviour {
        Sprite[] spritesArray = new Sprite[10];
        void Awake() {
            spritesArray[0] = Resources.Load<Sprite>("Sprites/Circle");
        }
    }
