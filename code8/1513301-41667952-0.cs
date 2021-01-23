    public class Timer : MonoBehaviour
    {
        public float timelimit;
        public Text text;
        static bool loadedScene = false;
    
        public void ChangeScene(int changeTheScene)
    
        {
            //SceneManager.LoadScene(changeTheScene);
        }
    
  
        void Update()
        {
            //Exit if we have already loaded scene
            if (loadedScene)
            {
                //Destroy Timer Text
                Destroy(text.gameObject);
                //Destroy this Timer GameObject and Script
                Destroy(gameObject);
                return;
            }
    
            timelimit -= Time.deltaTime;
            text.text = "TimerText:" + Mathf.Round(timelimit);
            if (timelimit < 0)
            {
                timelimit = 0;
                loadedScene = true; //We have loaded Scene so mark it true
                SceneManager.LoadScene(1);
            }
        }
    }
