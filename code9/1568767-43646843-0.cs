    using UnityStandardAssets.Characters.FirstPerson;
    
    public class Fpstest : MonoBehaviour
    {
        FirstPersonController fps;
    
        // Use this for initialization
        void Start()
        {
            GameObject fpObj = GameObject.Find("FPSController");
            fps = fpObj.GetComponent<FirstPersonController>();
            fps.mouseLookCustom.XSensitivity = 5;
        }
    }
