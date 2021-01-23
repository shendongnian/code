    public class SceneFader : MonoBehaviour
    {
        //WARNING : I changed this parameter name for better understanding
        float lerpDuration = 1; // Time of the Change of the Colors
        void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
    
        internal Camera GetCamera() // Get the current camera of the scene
        {
            return GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        }
    
        internal void SceneFadeIn(Camera camera, Color defaultColor, Color sceneChangeColor, float lerpValue) // Is called at the new scene
        {
            camera.backgroundColor = Color.Lerp(sceneChangeColor, defaultColor, lerpValue);
        }
    
        internal void SceneFadeOut(Camera camera, Color defaultColor, Color sceneChangeColor, float lerpValue) // Is called at the previous scene
        {
            camera.backgroundColor = Color.Lerp(defaultColor, sceneChangeColor, lerpValue);
        }
    }
