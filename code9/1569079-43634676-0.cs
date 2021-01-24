    public class SceneLoader : MonoBehaviour
    {
        int loadToScene = 1;
        public void ChangeScene(int sceneLevel)
        {
            loadToScene = sceneLevel;
            Invoke("loadScene", 2f);
        }
    
        private void loadScene()
        {
            SceneManager.LoadScene(loadToScene);
        }
    }
