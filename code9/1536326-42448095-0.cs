    public class buttons : MonoBehaviour
    {
        public Button play;
        public Button shop;
        public Button exit;
    
        void OnEnable()
        {
            play.onClick.AddListener(() => loads(play));
            shop.onClick.AddListener(() => loads(shop));
            exit.onClick.AddListener(() => loads(exit));
        }
    
        void OnDisable()
        {
            play.onClick.RemoveListener(() => loads(play));
            shop.onClick.RemoveListener(() => loads(shop));
            exit.onClick.RemoveListener(() => loads(exit));
        }
    
        void loads(Button buttonPressed)
        {
            if (buttonPressed == play)
                SceneManager.LoadScene("level_1");
            else if (buttonPressed == shop)
                SceneManager.LoadScene("Shop_menu");
            else if (buttonPressed == exit)
                Application.Quit();
        }
    }
