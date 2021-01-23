    public class LookAtWatchController : MonoBehaviour
    {
        public GameObject menuGUI;
        public GameObject hand;
        void Update(){
              if(transform.eulerAngles.x > 10)
              {
                    menuGUI.transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, 0);
                    menuGUI.SetActive(true);
                    menuGUI.transform.position = hand.transform.position;
              }
              else{
                    menuGUI.SetActive(false);
              }
         }
    }
