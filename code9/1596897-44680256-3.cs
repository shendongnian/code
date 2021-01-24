    public class TestA
    {
      [RuntimeInitializeOnLoadMethod]
      static void RuntimeInitHelper() 
      {
    #if !UNITY_EDITOR
        OnInit(); // This will only run when NOT in editor
    #endif
      }
    
    #if UNITY_EDITOR
      [UnityEditor.InitializeOnLoadMethod]
    #endif
      static void OnInit() { Debug.Log("TEST A - This now prints in Standalone"); }
    }
