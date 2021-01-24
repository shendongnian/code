    public class CartMovement : MonoBehaviour {
    SpriteRenderer spriteRenderer;
    // Make it public, so it is visible in the inspector, and drag and drop the object into that instance
    public LevelManager LevelManIns; 
        void Start () {
            // No need to assign it here, just maybe check if it is assigned like so
            if (LevelManIns == null)
                // Error, this should be assign outside
        }
    }
