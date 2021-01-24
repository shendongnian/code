    public string SceneName ; // Indicate which level this button must load once you click on it. Be carefull, the name must be the same as in your Build Settings
     protected void Awake()
     {
         UnityEngine.UI.Button button = GetComponent<UnityEngine.UI.Button>();
 
         if( button != null )
         {
              // Make the button load the given scene
              button.onClick.AddListener( () => UnityEngine.SceneManagement.SceneManager.LoadScene( SceneName ) ) ;
              // Make the button interactable only if the given scene / level has been completed
              button.interactable = PlayerPrefs.GetInt( SceneName ) > 0 ;
         }
         else
             Debug.LogWarning("No button component attached", this ) ;
     }
    
