    [InitializeOnLoad]
    public class MyWindow : ScriptableObject
    {
        static string pathToScript;
    
        [MenuItem("Window/My Window")]
        static void Open()
        {
            Debug.Log("Open:" + pathToScript);
            //Do something with `pathToScript`
        }
    
        protected void OnEnable()
        {
            Debug.Log("Enabled!");
            var script = MonoScript.FromScriptableObject(this);
            pathToScript = AssetDatabase.GetAssetPath(script);
        }
    }
