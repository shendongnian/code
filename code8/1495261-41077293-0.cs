    public class TankManager : MonoBehaviour
    {
    public Camera camera;
    FollowCamera followC;
        void Start()
        {
            GameObject target = Instantiate (MenuManager.SelectedCharacter, Vector3.zero, Quaternion.identity);
            followC = camera.GetComponent <FollowCamera>();
            followC.target = target;
       }
    }
