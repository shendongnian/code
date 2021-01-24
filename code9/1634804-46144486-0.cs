    public class ExampleScript : MonoBehaviour
    {
        /// <summary>
        /// Store the ExampleScript in a static variable, then have the variable set when the scene is loaded, for example through OnEnable() or possibly Awake().
        /// ExampleScript should act as a manager script and hold the references to the buttons in each scene.
        /// </summary>
        public static ExampleScript _Instance;
    
        private void OnEnable()
        {
            _Instance = this;
        }
    
    }
    
    public class UsingExampleScript : MonoBehaviour
    {
    
        private void Update()
        {
            if (Input.GetKeyDown("i"))
            {
                if (ExampleScript._Instance != null)
                {
                    //Use variables from example script, for example the buttons.
                }
            }
        }
    }
